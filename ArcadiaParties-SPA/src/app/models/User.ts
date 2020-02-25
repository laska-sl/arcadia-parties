export interface User {
    identity: string;
    firstName: string;
    lastName: string;
    department: string;
    dates?: Date[];
    roles: string[];
}