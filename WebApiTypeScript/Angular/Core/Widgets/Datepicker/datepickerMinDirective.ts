module app.common.widgets {

    interface IAttributes extends ng.IAttributes {
        datepickerMin: string;
    }

    export class DatepickerMinDirective implements ng.IDirective {
        restrict = 'A';
        require = 'ngModel';

        constructor(private dateComperatorService: app.common.services.DateComperatorService) {

        }

        link = (scope: ng.IScope, element: ng.IAugmentedJQuery, attrs: IAttributes, ngModel: ng.INgModelController) => {
            var parser = (viewValue: ng.IModelParser): ng.IModelParser => {
                if (attrs.datepickerMin !== "") {
                    var tmpMin = attrs.datepickerMin;
                    tmpMin = tmpMin.replace(/\"/gi, "").replace(/\\/gi, "");
                    var minDate = moment(tmpMin);
                    var parts = ("" + viewValue).match(/(\d+)/g);
                    var viewDate = new Date(parseInt(parts[2]), parseInt(parts[1]) - 1, parseInt(parts[0]));
                    var isValid = true;
                    if (minDate && viewValue) {
                        isValid = this.dateComperatorService.isLowerOrEqualThan(minDate.toDate(), viewDate);
                    }

                    ngModel.$setValidity('validateMin', isValid);
                    return viewValue;
                }
                return viewValue;
            }
            
            if (ngModel) {
                ngModel.$parsers.unshift(parser);
            }
        }

        static factory(): ng.IDirectiveFactory {
            const directive = (dateComperatorService: app.common.services.DateComperatorService) => new DatepickerMinDirective(dateComperatorService);
            directive.$inject = ['dateComperatorService'];
            return directive;
        }
    }
    angular.module("common.widgets").directive('datepickerMin', DatepickerMinDirective.factory());
}