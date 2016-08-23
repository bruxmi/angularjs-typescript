declare module app.common.services {
    interface IDateComperatorService {
        isLowerOrEqualThan(leftDate: Date, rightDate: Date): boolean;
    }
    class DateComperatorService implements IDateComperatorService {
        constructor();
        isLowerOrEqualThan(leftDate: Date, rightDate: Date): boolean;
        getYearMonthDate(date: Date): number;
    }
}
