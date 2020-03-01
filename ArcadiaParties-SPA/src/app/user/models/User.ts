import { Department } from 'src/app/department/models/Department';

export interface User {
  identity: string;
  firstName: string;
  lastName: string;
  department: Department;
  dates?: CelebrationDate[];
  roles?: string[];
}

export interface CelebrationDate {
  name: string;
  date: Date;
}
