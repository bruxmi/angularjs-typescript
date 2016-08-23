declare module app.entity {
    interface IUser {
        firstName: string;
        lastName: string;
        id: number;
    }
    class User implements IUser {
        firstName: string;
        lastName: string;
        id: number;
    }
}
