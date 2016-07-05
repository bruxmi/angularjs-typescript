module app.user {
    export interface IUserDataService {
        getUser: () => ng.IHttpPromise<any>;
    }

    export class UserDataService implements IUserDataService{
        userQueryUrl: string;

        constructor(private dataAccessService: app.common.dataAccess.DataAccessService) {
            this.userQueryUrl = "userQuery"
        }

        getUser() {
            return this.dataAccessService.get(this.userQueryUrl);
        }
    }

    angular.module("common.services").service("userDataService", ["dataAccessService", UserDataService])
}