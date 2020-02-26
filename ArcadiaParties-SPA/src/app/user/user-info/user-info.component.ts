import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';

import { selectUser } from '../selector/selector';
import { Observable } from 'rxjs';
import { State } from '../../reducers/reducers';
import { User } from 'src/app/models/User';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements OnInit {
  user$: Observable<User> = this.store.pipe(select(selectUser));

  constructor(private store: Store<State>) {}

  ngOnInit() {}
}
