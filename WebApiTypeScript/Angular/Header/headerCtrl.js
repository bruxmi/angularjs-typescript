var HeaderCtrl = (function () {
    function HeaderCtrl() {
        this.type = "I got it";
        this.gridOptions = [];
        this.gridOptions.columnDefs = [
            { name: "firstName", displayName: "Vorname" },
            { name: "lastName", displayName: "Nachname" }
        ];
        this.gridOptions.data = [
            { "firstName": "Max", "lastName": "Mustermann" },
            { "firstName": "Mäxchen", "lastName": "Kann nichts" },
        ];
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