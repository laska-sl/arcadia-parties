import { Routes } from '@angular/router';

import { ContentComponent } from './content/content.component';
import { DepartmentSelectorComponent } from './department/department-selector/department-selector.component';

export const appRoutes: Routes = [
  {
    path: 'calendar',
    children: [
      {
        path: '',
        component: ContentComponent
      },
      {
        path: '',
        outlet: 'departmentSelector',
        component: DepartmentSelectorComponent
      },
      {
        path: ':departmentId',
        component: ContentComponent
      }
    ]
  },
  { path: '**', redirectTo: 'calendar', pathMatch: 'full' }
];
