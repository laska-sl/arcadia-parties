import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';


import { Observable } from 'rxjs';

import { changeIdentityAction } from '../actions/actions';
import { State } from '../../reducers/reducers';
import { selectIdentity } from '../selector/selector';

@Component({
  selector: 'app-user-identity',
  templateUrl: './user-identity.component.html',
  styleUrls: ['./user-identity.component.scss']
})
export class UserIdentityComponent implements OnInit {

  identity$: Observable<string> = this.store.pipe(select(selectIdentity));

  constructor(private store: Store<State>) {
    store.dispatch(changeIdentityAction({ identity: 'ekaterina.kuznetsova' }));
  }

  ngOnInit() {
  }

}
