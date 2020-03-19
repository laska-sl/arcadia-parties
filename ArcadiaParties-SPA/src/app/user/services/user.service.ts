import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { AppSettingsService } from 'src/app/app-settings/app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private appSettingsService: AppSettingsService, private http: HttpClient) {}

  getUser(): Observable<User> {
    const baseUrl = this.appSettingsService.appSettings.apiUrl;
    return this.http.get<User>(baseUrl + 'Users/GetCurrentUser');
  }

  getUsers(): Observable<User[]> {
    const baseUrl = this.appSettingsService.appSettings.apiUrl;
    return this.http.get<User[]>(baseUrl + 'Users/GetUsers');
  }
}
