import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {
  HTTP_INTERCEPTORS,
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';

import { AuthService } from './auth.service';

@Injectable()
export class UnauthorizedInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      tap(
        null,
        (err: any) => {
          if (err instanceof HttpErrorResponse && err.status === 401) {
            this.authService.login();
          }
        }
      )
    );
  }
}

export const UnauthorizedInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: UnauthorizedInterceptor,
  multi: true
};
