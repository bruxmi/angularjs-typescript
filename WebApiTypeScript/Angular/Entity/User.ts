module app.entity {

    export interface IUser {
        firstName: string;
        lastName: string;
        id: number;
    }

    export class User implements IUser{
        
        firstName: string;
        lastName: string;
        id: number;
    }
}