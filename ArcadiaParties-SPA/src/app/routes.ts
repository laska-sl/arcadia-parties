import { Routes } from '@angular/router';

import { ContentComponent } from './content/content.component';

export const appRoutes: Routes = [
  { path: 'home', component: ContentComponent },
  { path: 'home/:departmentId', component: ContentComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
