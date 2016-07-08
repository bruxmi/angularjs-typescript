var app;
(function (app) {
    var user;
    (function (user_1) {
        'use strict';
        var UserCtrl = (function () {
            function UserCtrl(userDataService, $q) {
                var _this = this;
                this.userDataService = userDataService;
                this.$q = $q;
                this.successUser = function (user) {
                    _this.currentUser = user;
                };
                this.successUsers = function (user) {
                    _this.gridOptions.data = user;
                };
                this.fail = function (error) {
                    var msg = error.data.description;
                    var reason = 'query for people failed.';
                };
                this.currentUser = new app.entity.User();
                this.date = new Date();
                this.gridOptions = [];
                this.gridOptions.columnDefs = [
                    { name: "firstName", displayName: "Vorname" },
                    { name: "lastName", displayName: "Nachname" }
                ];
                this.getUser();
            }
            UserCtrl.prototype.getUser = function () {
                this.userDataService.getUser().then(this.successUsers);
            };
            UserCtrl.prototype.getUserById = function () {
                this.userDataService.getUserById(1).then(this.successUser).catch(this.fail);
            };
            return UserCtrl;
        }());
        angular.module("TypeScriptApp").controller("UserCtrl", ["userDataService", "$q", UserCtrl]).
            directive('user', function () {
            return {
                restrict: 'E',
                templateUrl: '/Angular/User/user.html',
                controller: UserCtrl,
                controllerAs: 'User'
            };
        });
    })(user = app.user || (app.user = {}));
})(app || (app = {}));
//# sourceMappingURL=userCtrl.js.map