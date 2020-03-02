import { Component, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { Observable, merge, Subscription } from 'rxjs';
import { takeUntil, map, filter, debounceTime } from 'rxjs/operators';

import { changeTitleAction } from '../actions/actions';
import { selectUser } from '../user/selector/selector';
import { changeDepartmentIdAction } from '../department/actions/actions';
import { selectCurrentDepartment } from '../department/selector/selector';
import { SelectedDepartmentIdState } from '../department/reducers/selected-department-reducer';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnDestroy {
  private mergedObservableSubscription: Subscription;

  currentDepartmentId$ = this.store.pipe(select(selectCurrentDepartment));

  constructor(private store: Store<SelectedDepartmentIdState>, route: ActivatedRoute) {
    store.dispatch(changeTitleAction({ title: 'Arcadia Parties' }));

    const routeParams$ = route.params.pipe(filter(params => params.departmentId));

    const currentUserDepartment$ = this.store
      .pipe(select(selectUser))
      .pipe(
        takeUntil(routeParams$),
        map(user => user.department.id)
      );

    const mergedObservable$ = merge(
      currentUserDepartment$,
      routeParams$.pipe(map(params => params.departmentId))
    ).pipe(debounceTime(500));

    this.mergedObservableSubscription = mergedObservable$
      .subscribe(id => this.store.dispatch(changeDepartmentIdAction({ departmentId: id })));
  }

  ngOnDestroy() {
    this.mergedObservableSubscription.unsubscribe();
  }
}
