declare module app.common.widgets {
    interface IDatepickerAttributes extends ng.IAttributes {
        datepickerMin: string;
    }
    class DatepickerMinDirective implements ng.IDirective {
        private dateComperatorService;
        restrict: string;
        require: string;
        constructor(dateComperatorService: app.common.services.DateComperatorService);
        link: (scope: ng.IScope, element: ng.IAugmentedJQuery, attrs: IDatepickerAttributes, ngModel: ng.INgModelController) => void;
        static factory(): ng.IDirectiveFactory;
    }
}
