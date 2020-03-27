import { createEffect, ofType, Actions } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';

import { DepartmentService } from '../services/department.service';
import { loadDepartmentsSuccessAction, loadDepartmentsAction, changeDepartmentIdAction } from '../actions/actions';
import { loadUserSuccessAction } from 'src/app/user/actions/actions';

@Injectable()
export class DepartmentEffect {
  changeDepartmentId = createEffect(() =>
    this.actions.pipe(
      ofType(loadUserSuccessAction),
      map(props => changeDepartmentIdAction({ departmentId: props.user.department.id }))
    )
  );

  loadDepartments = createEffect(() =>
    this.actions.pipe(
      ofType(loadDepartmentsAction),
      switchMap(() => this.departmentService.getDepartments()),
      map(departmentsFromService => loadDepartmentsSuccessAction({ departments: departmentsFromService }))
    )
  );

  constructor(private actions: Actions, private departmentService: DepartmentService) {}
}
