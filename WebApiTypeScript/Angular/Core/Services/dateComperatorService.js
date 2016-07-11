var app;
(function (app) {
    var common;
    (function (common) {
        var services;
        (function (services) {
            var DateComperatorService = (function () {
                function DateComperatorService() {
                    var a = 0;
                }
                DateComperatorService.prototype.isLowerOrEqualThan = function (leftDate, rightDate) {
                    var leftYearMonthDate = this.getYearMonthDate(leftDate);
                    var rightYearMonthDate = this.getYearMonthDate(rightDate);
                    if (leftYearMonthDate <= rightYearMonthDate) {
                        return true;
                    }
                    return false;
                };
                DateComperatorService.prototype.getYearMonthDate = function (date) {
                    var dateString = moment(date).format("YYYYMMDD");
                    var yearMonthDate = parseInt(dateString);
                    return yearMonthDate;
                };
                return DateComperatorService;
            }());
            services.DateComperatorService = DateComperatorService;
            angular.module("common.services").service("dateComperatorService", DateComperatorService);
        })(services = common.services || (common.services = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=dateComperatorService.js.map