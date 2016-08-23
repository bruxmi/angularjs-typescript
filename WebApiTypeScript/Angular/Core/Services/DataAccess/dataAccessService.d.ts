declare module app.common.dataAccess {
    interface IDataAccessService {
        getAll(url: string): ng.IPromise<any>;
        get(url: string, id: number): ng.IPromise<any>;
    }
    class DataAccessService implements IDataAccessService {
        private $http;
        constructor($http: ng.IHttpService);
        getAll(url: string): ng.IPromise<any>;
        get(url: string, id: number): ng.IPromise<any>;
    }
}
