﻿module app.user {
    'use strict';
    interface IUserCtrl {
        getUser(): void;
        getUserById(): void;
        currentUser: app.entity.IUser;
        gridOptions: uiGrid.IGridOptions;
        date: Date;
    }

    class UserCtrl implements IUserCtrl {

        gridOptions: uiGrid.IGridOptions;
        currentUser: app.entity.IUser;
        date: Date;
        isRequired: boolean;
        isReadonly: boolean;
        placement: string;

        constructor(private userDataService: app.user.UserDataService, private $q: ng.IQService) {
            this.currentUser = new app.entity.User();
            this.date = new Date();
            this.gridOptions = [];
            this.gridOptions.columnDefs = [
                { name: "firstName", displayName: "Vorname" },
                { name: "lastName", displayName: "Nachname" }
            ];
            this.getUser();
        }

        getUser() : void {
            this.userDataService.getUser().then(this.successUsers);
        }

        getUserById(): void {
            this.userDataService.getUserById(1).then(this.successUser).catch(this.fail);
        }

        private successUser = (user: app.entity.IUser): void => {
            this.currentUser = user;
        }

        private successUsers = (user: app.entity.IUser[]): void => {
            this.gridOptions.data = user;
        }

        private fail = (error: any) : void => {
            var msg = error.data.description;
            var reason = 'query for people failed.';
        }
    }

    angular.module("TypeScriptApp").controller("UserCtrl", ["userDataService", "$q", UserCtrl]).
        directive('user', function (): ng.IDirective {
            return {
                restrict: 'E',
                templateUrl: '/Angular/User/user.html',
                controller: UserCtrl,
                controllerAs: 'User'
            };
        });
}