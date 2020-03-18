import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import * as AuthenticationContext from 'adal-angular';
import { oauth } from 'src/adal-config/adal-config.json';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  context: AuthenticationContext;

  constructor() {
    console.log(oauth.clientId);
    this.context = new AuthenticationContext({
      clientId: oauth.clientId,
      tenant: oauth.tenant,
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
      this.context.acquireToken('7550c576-a91a-4bd6-8f47-5af6dc701a40', (_, token) => {
        subscriber.next(token);
      })
    );
  }
}
