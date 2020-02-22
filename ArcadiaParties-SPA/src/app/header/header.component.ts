import { Component, OnInit, Input } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { State } from '../reducers/reducers';

import { Observable } from 'rxjs';
import { selectTitle } from '../selector/selector';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  title$: Observable<string> = this.store.pipe(select(selectTitle));

  constructor(private store: Store<State>) { }

  ngOnInit() {

  }

}
