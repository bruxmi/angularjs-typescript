var _this = this;
describe('A dataAccessService', function () {
    beforeEach(angular.mock.module('common.services'));
    beforeEach(function () {
        _this.httpService = jasmine.createSpyObj('$http', ['get']);
    });
    it('should provide a get method which calls the get method of $http service', function () {
        var dataAccessService = new app.common.dataAccess.DataAccessService(_this.httpService);
        var result = dataAccessService.get("http://test", 1);
        expect(_this.httpService.get).toHaveBeenCalled();
        expect(result).not.toBeNull();
    });
});
//# sourceMappingURL=dataAccessServiceSpec.js.map