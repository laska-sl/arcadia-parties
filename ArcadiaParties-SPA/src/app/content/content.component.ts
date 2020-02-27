import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import { changeTitleAction } from '../actions/actions';
import { State } from '../reducers/reducers';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {

  constructor(private store: Store<State>) {
    store.dispatch(changeTitleAction({ title: 'Acradia Parties' }));
  }

  ngOnInit() {
  }

}
