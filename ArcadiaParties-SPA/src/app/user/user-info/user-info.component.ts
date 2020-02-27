import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { selectUser } from '../selector/selector';
import { State } from '../../reducers/reducers';
import { User } from '../models/User';
import { changeTitleAction } from 'src/app/actions/actions';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  user$: Observable<User> = this.store.pipe(select(selectUser));

  constructor(private store: Store<State>) {
    store.dispatch(changeTitleAction({ title: 'Acradia Parties - User Profile' }));
  }

  ngOnInit() { }
}
