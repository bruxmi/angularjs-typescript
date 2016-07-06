module app.user {
    export interface IUserDataService {
        getUser(): ng.IPromise<app.entity.IUser[]>;
        getUserById(id: number): ng.IPromise<app.entity.IUser>;
    }

    export class UserDataService implements IUserDataService{
        userQueryUrl: string;

        constructor(private dataAccessService: app.common.dataAccess.DataAccessService) {
            this.userQueryUrl = "userQuery"
        }

        getUser(): ng.IPromise<app.entity.IUser[]>{
            return this.dataAccessService.getAll(this.userQueryUrl).
                then((response: ng.IHttpPromiseCallbackArg<app.entity.IUser[]>) => {
                    return response.data
                });
        }

        getUserById(id: number): ng.IHttpPromise<app.entity.IUser>{
            return this.dataAccessService.get(this.userQueryUrl, id).
                then((response: ng.IHttpPromiseCallbackArg<app.entity.IUser>) => {
                    return response.data
                });
        }
    }

    angular.module("common.services").service("userDataService", ["dataAccessService", UserDataService])
}