var app = angular.module('TypeScriptApp', ['ngRoute']);
app.config(["$routeProvider", routeConfig]);
function routeConfig($routeProvider) {
    $routeProvider
        .when("/", {
        templateUrl: "Angular/Header/header.html",
        controller: "HeaderCtrl"
    })
        .otherwise("/");
}
//# sourceMappingURL=App.js.map