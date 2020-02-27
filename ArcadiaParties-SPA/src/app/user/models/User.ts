export interface User {
  identity: string;
  firstName: string;
  lastName: string;
  department: string;
  dates?: CelebrationDate[];
  roles?: string[];
}

export interface CelebrationDate {
  name: string;
  date: Date;
}
