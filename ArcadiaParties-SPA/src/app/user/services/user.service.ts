import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUser(): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'Users/GetCurrentUser');
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'Users/GetUsers');
  }
}
