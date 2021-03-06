var app;
(function (app) {
    var common;
    (function (common) {
        var dataAccess;
        (function (dataAccess) {
            var DataAccessService = (function () {
                function DataAccessService($http) {
                    this.$http = $http;
                }
                DataAccessService.prototype.getAll = function (url) {
                    return this.$http.get('/api/' + url);
                };
                DataAccessService.prototype.get = function (url, id) {
                    return this.$http.get('/api/' + url + "/" + id);
                };
                return DataAccessService;
            }());
            dataAccess.DataAccessService = DataAccessService;
            angular.module("common.services").service("dataAccessService", ['$http', DataAccessService]);
        })(dataAccess = common.dataAccess || (common.dataAccess = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=dataAccessService.js.map