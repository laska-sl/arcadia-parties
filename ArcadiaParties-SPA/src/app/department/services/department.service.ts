import { Injectable } from '@angular/core';
import { Department } from '../models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  private mockDepartments: Department[] = [
    { id: 1, name: 'Department1' },
    { id: 2, name: 'Department2' },
    { id: 3, name: 'Department3' },
    { id: 4, name: 'horoshiy' }
  ];

  getDepartments() {
    return this.mockDepartments;
  }
}
