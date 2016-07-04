var HeaderCtrl = (function () {
    function HeaderCtrl() {
        console.log("HeaderCtrl loaded");
        this.type = "I got it";
    }
    return HeaderCtrl;
})();
angular.module("TypeScriptApp").controller("HeaderCtrl", HeaderCtrl).
    directive('header', function () {
    return {
        restrict: 'E',
        templateUrl: '/Angular/Header/header.html',
        controller: HeaderCtrl,
        controllerAs: "Header"
    };
});
//# sourceMappingURL=headerCtrl.js.map