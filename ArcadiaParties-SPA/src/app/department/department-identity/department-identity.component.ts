import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Router } from '@angular/router';
import { Observable, combineLatest } from 'rxjs';
import { map } from 'rxjs/operators';

import { DepartmentsState } from '../reducers/reducer';
import { loadDepartmentsAction } from '../actions/actions';
import { selectDepartments, selectCurrentDepartment } from '../selector/selector';
import { User } from 'src/app/user/models/User';
import { selectUser } from 'src/app/user/selector/selector';
import { Department } from '../models/Department';

@Component({
  selector: 'app-department-identity',
  templateUrl: './department-identity.component.html',
  styleUrls: ['./department-identity.component.scss']
})
export class DepartmentIdentityComponent {
  currentUser$: Observable<User> = this.store.pipe(select(selectUser));

  departments$: Observable<Department[]> = this.store.pipe(select(selectDepartments));

  currentDepartmentId$: Observable<number> = this.store.pipe(select(selectCurrentDepartment));

  selectedDepartment: Department;

  constructor(private store: Store<DepartmentsState>, private router: Router) {
    store.dispatch(loadDepartmentsAction());

    const combined = combineLatest([
      this.departments$,
      this.currentDepartmentId$]
    ).pipe(map(([departments, departmentId]) => departments.find(d => d.id === departmentId)))
      .subscribe(d => this.selectedDepartment = d);
  }

  onChange() {
    this.router.navigate(['/home', this.selectedDepartment.id]);
  }
}
