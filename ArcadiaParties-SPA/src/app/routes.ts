import { Routes } from '@angular/router';
import { ContentComponent } from './content/content.component';
import { UserInfoComponent } from './user/user-info/user-info.component';

export const appRoutes: Routes = [
  { path: 'home', component: ContentComponent },
  { path: 'user', component: UserInfoComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
