module app.entity {

    export interface IUser {
        FirstName: string;
        LastName: string;
		Id: number;
    }

    export class User implements IUser{
        
        FirstName: string;
        LastName: string;
        Id: number;
    }
}