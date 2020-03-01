import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { DepartmentsState } from '../reducers/reducer';
import { loadDepartmentsAction } from '../actions/actions';
import { selectDepartments } from '../selector/selector';
import { User } from 'src/app/user/models/User';
import { selectUser } from 'src/app/user/selector/selector';
import { Router } from '@angular/router';
import { Department } from '../models/Department';

@Component({
  selector: 'app-department-identity',
  templateUrl: './department-identity.component.html',
  styleUrls: ['./department-identity.component.scss']
})
export class DepartmentIdentityComponent implements OnInit {
  currentUser$: Observable<User> = this.store.pipe(select(selectUser));

  departments$: Observable<Department[]> = this.store.pipe(select(selectDepartments));

  selectedDepartmentId: number;

  constructor(private store: Store<DepartmentsState>, private router: Router) {
    store.dispatch(loadDepartmentsAction());
  }

  ngOnInit() {
    this.currentUser$.subscribe(currentUser => this.selectedDepartmentId = currentUser.department.id);
  }

  onChange() {
    this.router.navigate(['/home', this.selectedDepartmentId]);
  }
}
