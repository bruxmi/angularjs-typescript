((): void => {
    "use strict";

    angular.module("common.widgets").directive("datepickerMin", minCheck);

    function minCheck(): ng.IDirective {
        var directive = <ng.IDirective>{
            restrict: 'A',
            link: link
        }

        function link(scope: ng.IScope, element: ng.IAugmentedJQuery, attributes: ng.IAttributes, ngModel: ng.INgModelController): void {
            //ngModel.$parsers.unshift((value: string): Date => { });
            //ngModel.$parsers.unshift(function (viewValue: string) {
            //    //if (attributes.validateMax !== "") {
            //    //    return num;
            //    //}

            //    return viewValue;
            //});
        }

        return directive;
    }
})();