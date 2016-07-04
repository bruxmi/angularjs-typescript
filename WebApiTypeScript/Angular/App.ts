var app = angular.module('TypeScriptApp', ['ngRoute'])
app.config(["$routeProvider", routeConfig]);

function routeConfig($routeProvider: ng.route.IRouteProvider): void {
    $routeProvider
        .when("/", {
            templateUrl: "Angular/Header/header.html",
            controller: "HeaderCtrl"
        })
        .otherwise("/");
}
