import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import * as AuthenticationContext from 'adal-angular';

import { AppSettingsService } from '../app-settings/app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  context: AuthenticationContext;

  constructor(private appSettingsService: AppSettingsService) {
    this.context = new AuthenticationContext({
      clientId: appSettingsService.appSettings.oauth.clientId,
      tenant: appSettingsService.appSettings.oauth.tenant,
      cacheLocation: 'localStorage',
      redirectUri: appSettingsService.appSettings.oauth.redirectUri,
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
    return !!this.context.getCachedToken(this.appSettingsService.appSettings.oauth.clientId);
  }

  getAccessToken(): string {
    return this.context.getCachedToken(this.appSettingsService.appSettings.oauth.clientId);
  }

  acquireTokenResilient(): Observable<any> {
    return new Observable<any>((subscriber: Subscriber<any>) =>
      this.context.acquireToken(this.appSettingsService.appSettings.oauth.clientId, (_, token) => {
        subscriber.next(token);
      })
    );
  }
}
