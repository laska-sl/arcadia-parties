import { Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  {},
];

export const appRoutes: Routes = [
  { path: 'home', component: AppComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
