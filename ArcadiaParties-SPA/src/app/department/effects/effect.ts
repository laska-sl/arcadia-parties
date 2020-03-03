import { createEffect, ofType, Actions } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { DepartmentService } from '../services/department.service';
import { loadDepartmentsSuccessAction, loadDepartmentsAction } from '../actions/actions';

@Injectable()
export class DepartmentEffect {
    loadDepartments = createEffect(() =>
        this.actions.pipe(
            ofType(loadDepartmentsAction),
            map(() => loadDepartmentsSuccessAction({ departments: this.departmentService.getDepartments() }))
        )
    );

    constructor(private actions: Actions, private departmentService: DepartmentService) { }
}
