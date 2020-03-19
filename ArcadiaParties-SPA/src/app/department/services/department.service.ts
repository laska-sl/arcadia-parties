import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Department } from '../models/department';
import { AppSettingsService } from 'src/app/app-settings/app-settings.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  constructor(private http: HttpClient, private appSettingsService: AppSettingsService) { }

  getDepartments(): Observable<Department[]> {
    const apiUrl = this.appSettingsService.appSettings.apiUrl;
    return this.http.get<Department[]>(apiUrl + 'departments');
  }
}
