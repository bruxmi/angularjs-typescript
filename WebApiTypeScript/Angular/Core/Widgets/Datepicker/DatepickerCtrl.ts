module app.common.widgets {

    interface IDatepickerScope {
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
    }

    class DatePickerScope implements IDatepickerScope {
        ngModel: string;
        minDate: string;
        maxDate: string;
        pickerLabel: string;
        placeholder: string;
        pickerName: string;
        pickerCss: string;
        ngRequired: string;
        ngReadonly: string;
        placement: string;

        static instance(): IDatepickerScope {
            return new DatePickerScope;
        } 

        constructor() {
            this.ngModel = '=';
            this.minDate = '=';
            this.maxDate = '=';
            this.pickerLabel = '@';
            this.placeholder= '@';
            this.pickerName = '@';
            this.pickerCss = '@';
            this.ngRequired = '=';
            this.ngReadonly= '=';
            this.placement = '@?';
        }
    }

    export interface IDatepickerCtrl {
        format: string;
        isOpen: boolean;
        open(): void;
        popupPlacement: string;
    }

    export class DatepickerCtrl implements app.common.widgets.IDatepickerCtrl {

        format: string;
        isOpen: boolean;
        popupPlacement: string;

        constructor(private $scope: IDatepickerScope) {
            this.format = "dd.MM.yyyy";
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
                templateUrl: '/Angular/Core/Widgets/Datepicker/datepicker.html',
                controller: DatepickerCtrl,
                controllerAs: 'Datepicker',
                scope: DatePickerScope.instance()
            };
        });
}