module app {
    angular.module("common.services", ["ngResource"])
    var application = angular.module('TypeScriptApp', ["ngRoute", "ui.grid", "ui.grid.edit", "common.services"])


    application.config(["$routeProvider", routeConfig]);

    function routeConfig($routeProvider: ng.route.IRouteProvider): void {
        $routeProvider
            .when("/", {
                templateUrl: "Angular/User/user.html",
                controller: "UserCtrl"
            })
            .otherwise("/");
    }
}