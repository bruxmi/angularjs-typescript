var app;
(function (app) {
    var user;
    (function (user) {
        var UserDataService = (function () {
            function UserDataService(dataAccessService) {
                this.dataAccessService = dataAccessService;
                this.userQueryUrl = "userQuery";
            }
            UserDataService.prototype.getUser = function () {
                return this.dataAccessService.getAll(this.userQueryUrl).
                    then(function (response) {
                    return response.data;
                });
            };
            UserDataService.prototype.getUserById = function (id) {
                return this.dataAccessService.get(this.userQueryUrl, id).
                    then(function (response) {
                    return response.data;
                });
            };
            return UserDataService;
        }());
        user.UserDataService = UserDataService;
        angular.module("common.services").service("userDataService", ["dataAccessService", UserDataService]);
    })(user = app.user || (app.user = {}));
})(app || (app = {}));
//# sourceMappingURL=userDataService.js.map