'use strict';
describe('A Datepicker Directive', function () {

    var $httpBackend;
    var scope;
    var form;
    var pickerCtrl;
    var compile;
    var dirElement;
    var dirElementInput;

    beforeEach(function () {
        module('common.services');
        module('common.widgets');
    });

    beforeEach(inject(function ($injector, $compile, $rootScope) {
        $httpBackend = $injector.get('$httpBackend');
        $httpBackend.whenGET('uib/template/datepickerPopup/popup.html').respond(200, '');
        scope = $rootScope.$new();
        compile = $compile;
    }));

    beforeEach(function () {
        scope.displayformat = "dd.MM.yyyy";
        dirElement = angular.element('<form name="form"><datepicker class="col-md-3" options="options" format="{{displayformat}}" picker-name="mydate" placeholder="" placement="top-left" ng-model="ngModel" ng-readonly="false" ng-required="true"></form>');
        compile(dirElement)(scope);
        scope.$digest();
        dirElement.isolateScope();
        dirElementInput = dirElement.find('input');
    });

    it('a datepicker with format dd.MM.yyyy and date 2.4.2015 should display 2.3.2015', function () {
        scope.ngModel = new Date(2015, 3, 2);
        scope.$digest();
        expect(scope.form.mydate.$viewValue).toBe('02.04.2015');
    });

    it('a datepicker with minimum date 2.4.2014 and current date 20.11.2013 should have set property validateMin of $error set to true', function () {
        scope.options = {
            minDate: new Date(2014, 3, 2)
        };
        scope.$digest();
        angular.element(dirElementInput).val('20.11.2013').trigger('input');
        scope.$apply();
        expect(scope.form.mydate.$error.validateMin).toBe(true);
    });


    it('a datepicker with format dd/MM/yyyy and date 2.4.2015 should display 2/3/2015', function () {
        scope.displayformat = "dd/MM/yyyy";
        scope.ngModel = new Date(2015, 3, 2);
        scope.$digest();
        expect(scope.form.mydate.$viewValue).toBe('02/04/2015');
    });

    it('a datepicker with a valid date should have class ng-valid', function () {
        angular.element(dirElementInput).val('20.11.2016').trigger('input');
        scope.$apply();
        expect(dirElement.hasClass('ng-valid')).toBeTruthy();
        expect(scope.ngModel.toString()).toContain("2016");
    });

    it('a datepicker with format dd.MM.yyyy and a viewValue of 20/11/2016 should have class ng-invalid', function () {
        angular.element(dirElementInput).val('20/11/2016').trigger('input');
        scope.$apply();
        expect(dirElement.hasClass('ng-invalid')).toBeTruthy();
    });

    it('a datepicker with a viewValue of a number should have an error object with date property set to true', function () {
        angular.element(dirElementInput).val('32434').trigger('input');
        scope.$apply();
        expect(scope.form.mydate.$error.date).toBeTruthy();
    });
});
