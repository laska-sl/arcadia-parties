import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import * as AuthenticationContext from 'adal-angular';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  context: AuthenticationContext;

  constructor() {
    this.context = new AuthenticationContext({
      clientId: '7550c576-a91a-4bd6-8f47-5af6dc701a40',
      tenant: 'ea6365cd-cf52-4237-bafd-838a4864edd4',
      cacheLocation: 'localStorage',
      redirectUri: 'http://localhost:4200/token',
      popUp: true
    });
  }

  login() {
    this.context.login();
  }

  logout() {
    this.context.logOut();
  }

  loggedIn(): boolean {
    return !!this.context.getCachedToken('7550c576-a91a-4bd6-8f47-5af6dc701a40');
  }

  getAccessToken(): string {
    return this.context.getCachedToken('7550c576-a91a-4bd6-8f47-5af6dc701a40');
  }

  acquireTokenResilient(): Observable<any> {
    return new Observable<any>((subscriber: Subscriber<any>) =>
      this.context.acquireToken('7550c576-a91a-4bd6-8f47-5af6dc701a40', (message: string, token: string) => {
        if (token) {
          subscriber.next(token);
        } else {
          this.login();
        }
      })
    );
  }
}
