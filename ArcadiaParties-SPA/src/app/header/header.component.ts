import { Component } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { State } from '../reducers/reducers';
import { selectTitle } from '../selector/selector';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  title$: Observable<string> = this.store.pipe(select(selectTitle));

  constructor(private store: Store<State>, private authService: AuthService) { }

  loggedIn(): boolean {
    return this.authService.loggedIn();
  }

  login() {
    this.authService.login();
  }
}
