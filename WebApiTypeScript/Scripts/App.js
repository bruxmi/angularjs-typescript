//angular.module("TypeScriptApp", []);
angular.module('TypeScriptApp', ['ngRoute'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/Home', {
            templateUrl: 'Angular/Header/header.html',
            controller: 'HeaderCtrl'
        });
    }]);
//# sourceMappingURL=App.js.map