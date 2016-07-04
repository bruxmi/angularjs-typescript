


class HeaderCtrl {
    type: string;
    gridOptions: uiGrid.IGridOptions;

    constructor() {
        this.type = "I got it";
        this.gridOptions = [];
        this.gridOptions.columnDefs = [
            { name: "firstName", displayName: "Vorname" },
            { name: "lastName", displayName: "Nachname" }
        ];
        this.gridOptions.data = [
            { "firstName": "Max", "lastName": "Mustermann" },
            { "firstName": "Mäxchen", "lastName": "Kann nichts" },
        ]
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
