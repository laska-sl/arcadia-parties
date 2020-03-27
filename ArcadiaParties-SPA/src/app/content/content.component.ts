import { Component, OnDestroy } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { merge, Subscription } from 'rxjs';
import { takeUntil, map, filter, debounceTime } from 'rxjs/operators';

import { changeTitleAction } from '../actions/actions';
import { selectUserDepartmentId } from '../user/selector/selector';
import { changeDepartmentIdAction } from '../department/actions/actions';
import { selectCurrentDepartmentId } from '../department/selector/selector';
import { DepartmentState } from '../department/reducers/reducer';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnDestroy {
  private mergedObservableSubscription: Subscription;

  currentDepartmentId$ = this.store.pipe(select(selectCurrentDepartmentId));

  constructor(private store: Store<DepartmentState>, route: ActivatedRoute) {
    store.dispatch(changeTitleAction({ title: 'Arcadia Parties' }));

    const routeParams$ = route.params
      .pipe(
        filter(params => params.departmentId),
        map(params => +params.departmentId)
      );

    const currentUserDepartment$ = this.store
      .pipe(
        select(selectUserDepartmentId),
        takeUntil(routeParams$),
        map(id => id),
      );

    const mergedObservable$ = merge(
      currentUserDepartment$,
      routeParams$
    ).pipe(debounceTime(500));

    this.mergedObservableSubscription = mergedObservable$
      .subscribe(id => this.store.dispatch(changeDepartmentIdAction({ departmentId: id })));
  }

  ngOnDestroy() {
    this.mergedObservableSubscription.unsubscribe();
  }
}
