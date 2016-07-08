module app {
    angular.module("common.services", ["ngResource"])
    angular.module("common.widgets", ["ngAnimate", "ui.bootstrap"]);
    var appDependencies = ["ngRoute", "ui.grid", "ui.grid.edit", "common.services", "common.widgets"];

    var application = angular.module('TypeScriptApp', appDependencies)


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