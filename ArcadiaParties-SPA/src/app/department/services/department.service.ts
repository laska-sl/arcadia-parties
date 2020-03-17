import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Department } from '../models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getDepartments(): Observable<Department[]> {
    return this.http.get<Department[]>(this.baseUrl + 'departments');
  }
}
