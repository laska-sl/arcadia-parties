import { Component, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';

import { loadDepartmentsAction } from '../actions/actions';
import { selectDepartments, selectCurrentDepartmentId } from '../selector/selector';
import { Department } from '../models/Department';
import { DepartmentState } from '../reducers/reducer';

@Component({
  selector: 'app-department-selector',
  templateUrl: './department-selector.component.html',
  styleUrls: ['./department-selector.component.scss']
})
export class DepartmentSelectorComponent implements OnDestroy {
  private currentDepartmentSubscription: Subscription;

  departments$: Observable<Department[]> = this.store.pipe(select(selectDepartments));

  selectedDepartmentId: number;

  constructor(private store: Store<DepartmentState>, private router: Router) {
    store.dispatch(loadDepartmentsAction());

    this.currentDepartmentSubscription = this.store.pipe(select(selectCurrentDepartmentId))
      .subscribe(id => {
        this.selectedDepartmentId = id;
      });
  }

  onChange() {
    this.router.navigate(['/calendar', this.selectedDepartmentId]);
  }

  ngOnDestroy() {
    this.currentDepartmentSubscription.unsubscribe();
  }
}
