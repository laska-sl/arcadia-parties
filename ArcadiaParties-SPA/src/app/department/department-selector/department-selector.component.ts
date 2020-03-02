import { Component, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Router } from '@angular/router';
import { Observable, combineLatest, Subscription } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { DepartmentsState } from '../reducers/reducer';
import { loadDepartmentsAction } from '../actions/actions';
import { selectDepartments, selectCurrentDepartment } from '../selector/selector';
import { Department } from '../models/Department';

@Component({
  selector: 'app-department-selector',
  templateUrl: './department-selector.component.html',
  styleUrls: ['./department-selector.component.scss']
})
export class DepartmentSelectorComponent implements OnDestroy {
  private mergedObservableSubscription: Subscription;
  private currentDepartmentSubscription: Subscription;

  departments$: Observable<Department[]> = this.store.pipe(select(selectDepartments));

  selectedDepartmentId: number;
  selectedDepartmentName: string;

  constructor(private store: Store<DepartmentsState>, private router: Router) {
    store.dispatch(loadDepartmentsAction());

    // this.mergedObservableSubscription = combineLatest([
    //   this.departments$,
    //   this.store.pipe(select(selectCurrentDepartment))
    // ])
    //   .pipe(map(([departments, departmentId]) => departments.find(d => d.id === departmentId)))
    //   .pipe(filter(department => department !== undefined))
    //   .subscribe(d => this.selectedDepartmentName = d.name);


    this.currentDepartmentSubscription = this.store.pipe(select(selectCurrentDepartment)).subscribe(id => this.selectedDepartmentId = id);
  }

  onChange() {
    this.router.navigate(['/home', this.selectedDepartmentId]);
  }
  ngOnDestroy(): void {
    this.mergedObservableSubscription.unsubscribe();
    this.currentDepartmentSubscription.unsubscribe()
  }
}
