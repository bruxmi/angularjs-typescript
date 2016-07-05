var app;
(function (app) {
    angular.module("common.services", ["ngResource"]);
    var application = angular.module('TypeScriptApp', ["ngRoute", "ui.grid", "ui.grid.edit", "common.services"]);
    application.config(["$routeProvider", routeConfig]);
    function routeConfig($routeProvider) {
        $routeProvider
            .when("/", {
            templateUrl: "Angular/User/user.html",
            controller: "UserCtrl"
        })
            .otherwise("/");
    }
})(app || (app = {}));
//# sourceMappingURL=App.js.map