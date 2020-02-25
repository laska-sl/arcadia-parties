import { Component } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { State } from './reducers/reducers';
import { selectTitle } from './selector/selector';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title$: Observable<string> = this.store.pipe(select(selectTitle));

  constructor(private store: Store<State>) {
   
  }
}
