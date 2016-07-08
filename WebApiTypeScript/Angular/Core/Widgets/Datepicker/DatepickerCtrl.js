var app;
(function (app) {
    var common;
    (function (common) {
        var widgets;
        (function (widgets) {
            var DatepickerCtrl = (function () {
                function DatepickerCtrl($scope) {
                    this.$scope = $scope;
                    this.format = "dd.MM.yyyy";
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
                    templateUrl: '/Angular/Core/Widgets/Datepicker/datepicker.html',
                    controller: DatepickerCtrl,
                    controllerAs: 'Datepicker',
                    scope: {
                        ngModel: '=',
                        minDate: '=',
                        maxDate: '=',
                        pickerLabel: '@',
                        placeholder: '@',
                        pickerName: '@',
                        pickerCss: '@',
                        ngRequired: '=',
                        ngReadonly: '=',
                        placement: '@?'
                    }
                };
            });
        })(widgets = common.widgets || (common.widgets = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=DatepickerCtrl.js.map