import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  str: string;
  constructor(private http: HttpClient, private authService: AuthService) { }


  login() {
    this.authService.login();
  }

  apiMehtod() {
    this.http.get('http://localhost:5000/api/Users/GetCurrentUser')
      .subscribe(
        data => console.log(data),
        err => console.log(err)
      );
  }

  logout() {
    this.authService.logout();
  }
}
