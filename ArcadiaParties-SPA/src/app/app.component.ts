import { Component } from '@angular/core';
import {Store} from '@ngrx/store';

import {State} from './reducers';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ArcadiaParties-SPA';
  
  constructor(private store: Store<State>) {
    store.subscribe(state => console.log(state));   
  }
}