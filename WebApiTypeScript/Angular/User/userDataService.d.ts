declare module app.user {
    interface IUserDataService {
        getUser(): ng.IPromise<app.entity.IUser[]>;
        getUserById(id: number): ng.IPromise<app.entity.IUser>;
    }
    class UserDataService implements IUserDataService {
        private dataAccessService;
        userQueryUrl: string;
        constructor(dataAccessService: app.common.dataAccess.DataAccessService);
        getUser(): ng.IPromise<app.entity.IUser[]>;
        getUserById(id: number): ng.IHttpPromise<app.entity.IUser>;
    }
}
