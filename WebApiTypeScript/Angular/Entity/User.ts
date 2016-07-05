module app.entity {

    export interface IUser {
        firstName: string;
        lastName: string;
    }

    export class User implements IUser{
        firstName: string;
        lastName: string;
    }
}