var app;
(function (app) {
    var common;
    (function (common) {
        var widgets;
        (function (widgets) {
            var DatepickerMinDirective = (function () {
                function DatepickerMinDirective(dateComperatorService) {
                    var _this = this;
                    this.dateComperatorService = dateComperatorService;
                    this.restrict = 'A';
                    this.require = 'ngModel';
                    this.link = function (scope, element, attrs, ngModel) {
                        var parser = function (viewValue) {
                            if (attrs.datepickerMin !== "") {
                                var tmpMin = attrs.datepickerMin;
                                tmpMin = tmpMin.replace(/\"/gi, "").replace(/\\/gi, "");
                                var minDate = moment(tmpMin);
                                var parts = ("" + viewValue).match(/(\d+)/g);
                                var viewDate = new Date(parseInt(parts[2]), parseInt(parts[1]) - 1, parseInt(parts[0]));
                                var isValid = true;
                                if (minDate && viewValue) {
                                    isValid = _this.dateComperatorService.isLowerOrEqualThan(minDate.toDate(), viewDate);
                                }
                                ngModel.$setValidity('validateMin', isValid);
                                return viewValue;
                            }
                            return viewValue;
                        };
                        if (ngModel) {
                            ngModel.$parsers.unshift(parser);
                        }
                    };
                }
                DatepickerMinDirective.factory = function () {
                    var directive = function (dateComperatorService) { return new DatepickerMinDirective(dateComperatorService); };
                    directive.$inject = ['dateComperatorService'];
                    return directive;
                };
                return DatepickerMinDirective;
            }());
            widgets.DatepickerMinDirective = DatepickerMinDirective;
            angular.module("common.widgets").directive('datepickerMin', DatepickerMinDirective.factory());
        })(widgets = common.widgets || (common.widgets = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=datepickerMinDirective.js.map