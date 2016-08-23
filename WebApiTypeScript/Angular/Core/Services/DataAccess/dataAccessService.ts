module app.common.dataAccess {

    export interface IDataAccessService {
        getAll(url: string) : ng.IPromise<any>;
        get(url: string, id: number): ng.IPromise<any>;

    }

    export class DataAccessService implements IDataAccessService {
        
        constructor(private $http: ng.IHttpService) {
        }


        getAll(url: string): ng.IPromise<any> {
            return this.$http.get('/api/' + url);
        }

        get(url: string, id: number): ng.IPromise<any> {
            return this.$http.get('/api/' + url + "/" + id);
        }
    }
    angular.module("common.services").service("dataAccessService", ['$http', DataAccessService]);
}
