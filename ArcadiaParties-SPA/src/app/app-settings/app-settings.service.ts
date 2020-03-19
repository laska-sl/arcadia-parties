import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AppSettings } from './app-settings';

@Injectable({
  providedIn: 'root'
})
export class AppSettingsService {
  public appSettings: AppSettings;

  constructor(private http: HttpClient) { }

  async init() {
    console.log();
    const response = await this.http
      .get<AppSettings>('app-settings.json')
      .toPromise();
    this.appSettings = response;
  }
}
