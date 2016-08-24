module app.common.widgets {

    export interface IDatepickerScope extends ng.IScope {
        ngModel: string,
        minDate: string,
        maxDate: string,
        pickerLabel: string,
        placeholder: string,
        pickerName: string,
        pickerCss: string,
        ngRequired: string,
        ngReadonly: string,
        placement: string,
		options: string;
    }

    export interface IDatepickerCtrl {
        isOpen: boolean;
        open(): void;
        popupPlacement: string;
    }

    export class DatepickerCtrl implements app.common.widgets.IDatepickerCtrl {

        isOpen: boolean;
        popupPlacement: string;
        constructor(public $scope: IDatepickerScope) {
            this.isOpen = false;
            this.$scope.placement = angular.isDefined(this.$scope.placement) ? $scope.placement : 'bottom-left';
        }

        open(): void {
            if (!this.$scope.ngReadonly) {
                this.isOpen = !this.isOpen;
            }
        }
    }

    angular.module("common.widgets").controller("DatepickerCtrl", ["$scope", DatepickerCtrl]).
        directive("datepicker", function (): ng.IDirective {
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
				        'ngModel':'=',
						'pickerLabel' : '@',
						'placeholder' : '@',
						'pickerName' : '@',
						'pickerCss' :'@',
						'ngRequired' : '=',
						'ngReadonly' :'=',
						'placement': '@?',
						'format': '@',
						'options': '='
				}
            };
        });
}