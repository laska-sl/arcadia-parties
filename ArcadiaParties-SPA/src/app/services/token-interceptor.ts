import { HttpRequest, HttpInterceptor, HttpHandler, HttpEvent, HTTP_INTERCEPTORS, HttpErrorResponse } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { mergeMap, catchError } from 'rxjs/operators';

import { AuthService } from './auth.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  private authService: AuthService;

  constructor(private injector: Injector) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (request.url.includes('/api/')) {
      if (!this.authService) {
        this.authService = this.injector.get(AuthService);
      }

      return this.authService
        .acquireTokenResilient()
        .pipe(
          mergeMap(token => {
            if (token) {
              request = request.clone({
                setHeaders: {
                  Authorization: 'Bearer ' + token
                }
              });
            }
            return next.handle(request);
          }),
          catchError((err: HttpErrorResponse) => {
            if (err.status === 401) {
              this.authService.login();
            }
            return throwError(err);
          })
        );
    }
    return next.handle(request);
  }
}

export const TokenInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: TokenInterceptor,
  multi: true
};
