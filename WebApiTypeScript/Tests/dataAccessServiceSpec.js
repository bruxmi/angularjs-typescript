describe('A dataAccessService', function () {

    var httpService;
    beforeEach(angular.mock.module('common.services'));
    beforeEach(function () {
        httpService = jasmine.createSpyObj('$http', ['get']);
    });

    it('should provide a get method which calls the get method of $http service', function () {
        var dataAccessService = new app.common.dataAccess.DataAccessService(httpService);
        var result = dataAccessService.get("http://test", 1);
        expect(httpService.get).toHaveBeenCalled();
        expect(result).not.toBeNull();
    });
});
