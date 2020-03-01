import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { Observable, merge, interval } from 'rxjs';
import { takeUntil, map, debounce } from 'rxjs/operators';

import { changeTitleAction } from '../actions/actions';
import { selectUser } from '../user/selector/selector';
import { User } from '../user/models/User';
import { changeDepartmentIdAction } from '../department/actions/actions';
import { selectCurrentDepartment } from '../department/selector/selector';
import { SelectedDepartmentIdState } from '../department/reducers/selected-department-reducer';
import { UserState } from '../user/reducers/reducer';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent {
  currentUser$: Observable<User> = this.store.pipe(select(selectUser));
  tempString$ = this.store.pipe(select(selectCurrentDepartment));

  constructor(private store: Store<SelectedDepartmentIdState>, private route: ActivatedRoute) {
    store.dispatch(changeTitleAction({ title: 'Arcadia Parties' }));

    this.currentUser$ = this.currentUser$.pipe(takeUntil(this.route.params));

    const mergedObservable = merge(
      this.currentUser$.pipe(map(user => user.department.id)),
      this.route.params.pipe(map(params => params.departmentId))
    ).pipe(debounce(() => interval(500)));

    this.currentUser$.subscribe(id => this.store.dispatch(changeDepartmentIdAction({ departmentId: id.department.id })));

  }
}
