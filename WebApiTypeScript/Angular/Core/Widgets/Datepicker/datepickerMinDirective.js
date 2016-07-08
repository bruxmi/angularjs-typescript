(function () {
    "use strict";
    angular.module("common.widgets").directive("datepickerMin", minCheck);
    function minCheck() {
        var directive = {
            restrict: 'A',
            link: link
        };
        function link(scope, element, attributes, ngModel) {
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
//# sourceMappingURL=datepickerMinDirective.js.map