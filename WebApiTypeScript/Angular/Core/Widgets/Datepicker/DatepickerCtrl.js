var app;
(function (app) {
    var common;
    (function (common) {
        var widgets;
        (function (widgets) {
            var DatePickerScope = (function () {
                function DatePickerScope() {
                    this.ngModel = '=';
                    this.minDate = '=';
                    this.maxDate = '=';
                    this.pickerLabel = '@';
                    this.placeholder = '@';
                    this.pickerName = '@';
                    this.pickerCss = '@';
                    this.ngRequired = '=';
                    this.ngReadonly = '=';
                    this.placement = '@?';
                }
                DatePickerScope.instance = function () {
                    return new DatePickerScope;
                };
                return DatePickerScope;
            }());
            widgets.DatePickerScope = DatePickerScope;
            var DatepickerCtrl = (function () {
                function DatepickerCtrl($scope) {
                    this.$scope = $scope;
                    this.date = $scope.ngModel;
                    this.format = "dd/MM/yyyy";
                    this.isOpen = false;
                    this.$scope.placement = angular.isDefined(this.$scope.placement) ? $scope.placement : 'bottom-left';
                }
                DatepickerCtrl.prototype.open = function () {
                    if (!this.$scope.ngReadonly) {
                        this.isOpen = !this.isOpen;
                    }
                };
                return DatepickerCtrl;
            }());
            widgets.DatepickerCtrl = DatepickerCtrl;
            angular.module("common.widgets").controller("DatepickerCtrl", ["$scope", DatepickerCtrl]).
                directive("datepicker", function () {
                return {
                    restrict: 'E',
                    require: 'ngModel',
                    //templateUrl: '/Angular/Core/Widgets/Datepicker/datepicker.html',
                    template: "<div class=\"input-group\">"
                        + "    <input type=\"text\""
                        + "           id=\"{{pickerName}}\""
                        + "           name=\"{{pickerName}}\""
                        + "           class=\"form-control {{pickerCss}}\""
                        + "           placeholder=\"{{placeholder}}\""
                        + "           data-ng-model=\"ngModel\""
                        + "           data-min-date=\"minDate\""
                        + "           data-max-date=\"maxDate\""
                        + "           datepicker-min=\"{{minDate}}\""
                        + "           ng-disabled=\"ngReadonly\""
                        + "           ng-required=\"ngRequired\""
                        + "           placement=\"{{placement}}\""
                        + "           uib-datepicker-popup=\"{{Datepicker.format}}\""
                        + "           is-open=\"Datepicker.isOpen\""
                        + "           show-button-bar=\"false\""
                        + "           on-open-focus=\"true\""
                        + "           close-on-date-selection=\"true\" />"
                        + "    <label class=\"input-group-addon clickable\" for=\"{{pickerName}}\" ng-click=\"Datepicker.open()\">"
                        + "        <span class=\"glyphicon glyphicon-calendar clickable\"></span>"
                        + "    </label>"
                        + "</div>",
                    controller: DatepickerCtrl,
                    controllerAs: 'Datepicker',
                    scope: DatePickerScope.instance()
                };
            });
        })(widgets = common.widgets || (common.widgets = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=DatepickerCtrl.js.map