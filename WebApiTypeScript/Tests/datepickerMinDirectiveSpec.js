describe('A datepickerMinDirective', function () {

    var element;
    var ngModelCtrl;
    var scope;
    var dirElementInput;
    var dateComperatorService;

    function dateComperatorServiceMockShouldReturn(returnValue) {
        dateComperatorService.isLowerOrEqualThan = function (a, b) {
            return returnValue;
        }
    }

    beforeEach(function () {
        module('common.services');
        module('common.widgets');
        module(function ($provide) {
            $provide.service('dateComperatorService', function () {
                return {
                    isLowerOrEqualThan(left, right) {
                        return true
                    }
                };
            });
        });
    });

    beforeEach(inject(function ($injector, $compile, $rootScope) {
        scope = $rootScope.$new();
        element = $compile('<form name="myform"><input name="picker" ng-model="myDate" datepicker-min="{{minDate}}" /></form>')(scope);
        scope.$digest();
        element.isolateScope();
        ngModelCtrl = element.controller('ngModel');
        dirElementInput = element.find('input');
        dateComperatorService = $injector.get('dateComperatorService');
        spyOn(dateComperatorService, 'isLowerOrEqualThan');
    }));

    it('should detect that the date 30.03.2016 is lower than the min date 31.03.2016', function () {
        dateComperatorServiceMockShouldReturn(false);
        scope.minDate = new Date(2016, 2, 31);
        scope.$digest();
        angular.element(dirElementInput).val('30.03.2016').trigger('input');
        scope.$apply();
        expect(scope.myDate.toString()).toContain("2016");
        expect(scope.myform.picker.$error.validateMin).toBe(true);
    });

    it('should detect that the date 31.03.2016 is equal than the min date 31.03.2016 and valid', function () {
        scope.minDate = new Date(2016, 2, 31);
        scope.$digest();
        angular.element(dirElementInput).val('31.03.2016').trigger('input');
        scope.$apply();
        expect(scope.myform.picker.$error).toEqual({});
        expect()
    });

    it('should detect that the date 31.03.2017 is greater than the min date 31.03.2016 and valid', function () {
        scope.minDate = new Date(2016, 2, 31);
        scope.$digest();
        angular.element(dirElementInput).val('31.03.2017').trigger('input');
        scope.$apply();
        expect(scope.myform.picker.$error).toEqual({});
    });

    it('should not call isLowerOrEqualThan of dateComperatorService when no min date was set', function () {
        scope.$digest();
        angular.element(dirElementInput).val('31.03.2017').trigger('input');
        scope.$apply();
        expect(scope.myform.picker.$error).toEqual({});
        expect(dateComperatorService.isLowerOrEqualThan).not.toHaveBeenCalled();
    });

    it('should call isLowerOrEqualThan of dateComperatorService when min date was set', function () {
        scope.minDate = new Date(2016, 2, 31);
        scope.$digest();
        angular.element(dirElementInput).val('31.03.2017').trigger('input');
        scope.$apply();
        expect(scope.myform.picker.$error).toEqual({});
        expect(dateComperatorService.isLowerOrEqualThan).toHaveBeenCalled();
    });
});