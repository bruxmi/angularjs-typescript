describe('A dataAccessService', () => {

	beforeEach(angular.mock.module('common.services'));

	beforeEach(() => {
		this.httpService = jasmine.createSpyObj('$http', ['get']);
	});

	it('should provide a get method which calls the get method of $http service', () => {
		var dataAccessService = new app.common.dataAccess.DataAccessService(this.httpService);
		var result = dataAccessService.get("http://test", 1);
		expect(this.httpService.get).toHaveBeenCalled();
		expect(result).not.toBeNull();
	});
});