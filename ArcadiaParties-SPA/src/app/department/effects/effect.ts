import { createEffect, ofType, Actions } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import { map, switchMap } from 'rxjs/operators';

import { DepartmentService } from '../services/department.service';
import { loadDepartmentsSuccessAction, loadDepartmentsAction } from '../actions/actions';

@Injectable()
export class DepartmentEffect {
  loadDepartments = createEffect(() =>
    this.actions.pipe(
      ofType(loadDepartmentsAction),
      switchMap(() =>
        this.departmentService
          .getDepartments()),
      map(departmentsFromService => loadDepartmentsSuccessAction({ departments: departmentsFromService })))
  );

  constructor(private actions: Actions, private departmentService: DepartmentService) { }
}
