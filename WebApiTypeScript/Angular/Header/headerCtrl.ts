


class HeaderCtrl {
    type: string;
    constructor() {
        console.log("HeaderCtrl loaded");
        this.type = "I got it";
    }
}

angular.module("TypeScriptApp").controller("HeaderCtrl", HeaderCtrl).
    directive('header', function (): ng.IDirective {
    return {
        restrict: 'E',
        templateUrl: '/Angular/Header/header.html',
        controller: HeaderCtrl,
        controllerAs: "Header"
    };
});
