import { Routes } from '@angular/router';

import { ContentComponent } from './content/content.component';
import { DepartmentIdentityComponent } from './department/department-identity/department-identity.component';

export const appRoutes: Routes = [
  {
    path: 'home',
    children: [
      {
        path: '',
        component: ContentComponent
      },
      {
        path: '',
        outlet: 'departmentSelector',
        component: DepartmentIdentityComponent
      },
      {
        path: ':departmentId',
        component: ContentComponent
      }
    ]
  },
  // { path: 'user', component: DepartmentIdentityComponent, outlet: 'departmentSelector' },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
