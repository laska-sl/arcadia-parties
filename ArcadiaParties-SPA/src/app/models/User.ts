import { Dates } from './Dates';

export interface User {
  identity: string;
  firstName: string;
  lastName: string;
  department: string;
  dates?: Dates[];
  roles?: string[];
}
