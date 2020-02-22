import { Component } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';

import { State } from './reducers/reducers';
import { selectTitle } from './selector/selector';
import { changeTitleAction } from './actions/actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title$: Observable<string> = this.store.pipe(select(selectTitle));

  constructor(private store: Store<State>) {
    store.dispatch(changeTitleAction({ title: 'ArcadiaParties-SPA' }));
  }
}
