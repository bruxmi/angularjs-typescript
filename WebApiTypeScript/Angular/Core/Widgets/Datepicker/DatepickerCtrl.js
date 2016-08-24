var app;
(function (app) {
    var common;
    (function (common) {
        var widgets;
        (function (widgets) {
            var DatepickerCtrl = (function () {
                function DatepickerCtrl($scope) {
                    this.$scope = $scope;
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
                        + "           datepicker-min=\"{{options.minDate}}\""
                        + "           ng-disabled=\"ngReadonly\""
                        + "           ng-required=\"ngRequired\""
                        + "           placement=\"{{placement}}\""
                        + "           uib-datepicker-popup=\"{{format}}\""
                        + "           is-open=\"Datepicker.isOpen\""
                        + "           show-button-bar=\"false\""
                        + "           on-open-focus=\"true\""
                        + "			  datepicker-options=\"options\""
                        + "           close-on-date-selection=\"true\" />"
                        + "    <label class=\"input-group-addon clickable\" for=\"{{pickerName}}\" ng-click=\"Datepicker.open()\">"
                        + "        <span class=\"glyphicon glyphicon-calendar clickable\"></span>"
                        + "    </label>"
                        + "</div>",
                    controller: DatepickerCtrl,
                    controllerAs: 'Datepicker',
                    scope: {
                        'ngModel': '=',
                        'pickerLabel': '@',
                        'placeholder': '@',
                        'pickerName': '@',
                        'pickerCss': '@',
                        'ngRequired': '=',
                        'ngReadonly': '=',
                        'placement': '@?',
                        'format': '@',
                        'options': '='
                    }
                };
            });
        })(widgets = common.widgets || (common.widgets = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=DatepickerCtrl.js.map