//'use strict';
//describe('A Datepicker Directive', () => {

//	beforeEach(() => {
//		angular.mock.module('common.services');
//		angular.mock.module('common.widgets');
//	});

//	var $httpBackend;
//	var pickerCtrl;
//	var scope;
//	beforeEach(inject(function ($injector) {
//		$httpBackend = $injector.get('$httpBackend');
//		$httpBackend.whenGET('uib/template/datepickerPopup/popup.html').respond(200, '');
//	}));

//	it('Replaces the element with the appropriate content', angular.mock.inject(function ($compile: ng.ICompileService, $rootScope: ng.IRootScopeService): void {
//		 //Compile a piece of HTML containing the directive
//		var scope = $rootScope.$new();
//		var date = new Date();
//		var html = '<datepicker class="col-md-3" picker-name="date" placeholder="" placement="top-left" ng-model="date" ng-readonly="false" ng-required="true">';
//		var element = $compile(html)(scope);

//		// fire all the watches, so the scope expression will be evaluated
//		scope.$digest();
//		var dirElementInput = element.find('datepicker');
//		angular.element(dirElementInput).val('20.03.2016').triggerHandler('input');
//		scope.$apply();

//		var val = dirElementInput.val();
//		// Check that the compiled element contains the templated content
//		var model = pickerCtrl.date;
//		//expect(element.html()).toContain("2016");
//	}));
//});