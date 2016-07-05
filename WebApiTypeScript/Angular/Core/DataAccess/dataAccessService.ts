module app.common.dataAccess {

    export interface IDataAccessService {
        get: (url: string) => ng.IHttpPromise<any>;
    }

    export class DataAccessService implements IDataAccessService {
        
        constructor(private $http: ng.IHttpService, private $q: ng.IQService) {
        }


        get(url: string) {
            return this.$http.get('/api/' + url);
        }
    }
    angular.module("common.services").service("dataAccessService", ['$http', '$q', DataAccessService]);
}
