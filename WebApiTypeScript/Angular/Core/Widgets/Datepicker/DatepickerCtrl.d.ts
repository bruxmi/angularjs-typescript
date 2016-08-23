declare module app.common.widgets {
    interface IDatepickerScope {
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
        static instance(): IDatepickerScope;
        constructor();
    }
    interface IDatepickerCtrl {
        format: string;
        isOpen: boolean;
        open(): void;
        popupPlacement: string;
    }
    class DatepickerCtrl implements app.common.widgets.IDatepickerCtrl {
        private $scope;
        format: string;
        isOpen: boolean;
        popupPlacement: string;
        constructor($scope: IDatepickerScope);
        open(): void;
    }
}
