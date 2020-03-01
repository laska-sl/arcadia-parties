import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

import { changeTitleAction } from '../actions/actions';
import { State } from '../reducers/reducers';
import { selectUser } from '../user/selector/selector';
import { User } from '../user/models/User';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {
  currentUser$: Observable<User> = this.store.pipe(select(selectUser));
  tempString: string;

  constructor(private store: Store<State>, private route: ActivatedRoute) {
    store.dispatch(changeTitleAction({ title: 'Arcadia Parties' }));
  }

  ngOnInit() {
    this.currentUser$.subscribe(user => this.tempString = user.department);

    this.route.params.subscribe(params => {
      this.tempString = params.department;
    });
  }
}
