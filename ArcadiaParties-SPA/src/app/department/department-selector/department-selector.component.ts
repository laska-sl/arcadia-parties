import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Router } from '@angular/router';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { DepartmentsState } from '../reducers/reducer';
import { loadDepartmentsAction } from '../actions/actions';
import { selectDepartments, selectCurrentDepartment } from '../selector/selector';
import { Department } from '../models/Department';

@Component({
  selector: 'app-department-selector',
  templateUrl: './department-selector.component.html',
  styleUrls: ['./department-selector.component.scss']
})
export class DepartmentSelectorComponent {
  departments$: Observable<Department[]> = this.store.pipe(select(selectDepartments));

  selectedDepartment: Department;

  constructor(private store: Store<DepartmentsState>, private router: Router) {
    store.dispatch(loadDepartmentsAction());

    combineLatest([
      this.departments$,
      this.store.pipe(select(selectCurrentDepartment))
    ])
      .pipe(map(([departments, departmentId]) => departments.find(d => d.id === departmentId)))
      .subscribe(d => this.selectedDepartment = d);
  }

  onChange() {
    this.router.navigate(['/home', this.selectedDepartment.id]);
  }
}
