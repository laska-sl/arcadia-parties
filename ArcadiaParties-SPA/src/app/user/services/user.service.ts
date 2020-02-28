import { Injectable } from '@angular/core';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  mockUser = {
    identity: 'ekaterina.kuznetsova',
    firstName: 'ekaterina',
    lastName: 'kuznetsova',
    department: 'horoshiy',
    dates: [
      { name: 'BirthDay', date: new Date('11.02.1944') },
      { name: 'HireDay', date: new Date('03.12.1955') }
    ],
    roles: ['User', 'Admin']
  } as User;

  getUser() {
    return this.mockUser;
  }
}
