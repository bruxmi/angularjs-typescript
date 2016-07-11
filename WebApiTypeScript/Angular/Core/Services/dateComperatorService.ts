module app.common.services {

    export interface IDateComperatorService {
        isLowerOrEqualThan(leftDate: Date, rightDate: Date): boolean;
    }

    export class DateComperatorService implements IDateComperatorService {

        constructor() {
            var a = 0;
        }

        isLowerOrEqualThan(leftDate: Date, rightDate: Date): boolean {
            var leftYearMonthDate = this.getYearMonthDate(leftDate);
            var rightYearMonthDate = this.getYearMonthDate(rightDate);

            if (leftYearMonthDate <= rightYearMonthDate) {
                return true;
            }
            return false;
        }

        getYearMonthDate(date: Date): number {
            var dateString = moment(date).format("YYYYMMDD");
            var yearMonthDate = parseInt(dateString);
            return yearMonthDate;
        }
    }
    angular.module("common.services").service("dateComperatorService", DateComperatorService);
}
