import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ContentComponent } from './content/content.component';

export const appRoutes: Routes = [
  {
    path: 'home',
    children: [
      { path: '', component: ContentComponent }
    ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' }
];
