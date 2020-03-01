import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { DepartmentState } from '../reducers/reducer';
import { loadDepartmentAction } from '../actions/actions';
import { selectDepartment } from '../selector/selector';

@Component({
  selector: 'app-department-identity',
  templateUrl: './department-identity.component.html',
  styleUrls: ['./department-identity.component.scss']
})
export class DepartmentIdentityComponent {
  department$: Observable<string> = this.store.pipe(select(selectDepartment));

  constructor(private store: Store<DepartmentState>) {
    store.dispatch(loadDepartmentAction());
  }
}
