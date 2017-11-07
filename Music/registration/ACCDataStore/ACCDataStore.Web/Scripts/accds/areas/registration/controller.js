angular.module('root.controllers', ['ngSanitize'])

    .controller('rootCtrl', function ($scope, $rootScope) {
        $rootScope.pageTitle = "User Settings";
    })

    // ADDED CONTROLLER
    .controller('Registration', function ($scope, $window) {
        $window.location = 'http://www.google.com'
    })

    .controller('listCtrl', function ($scope, $window, $rootScope, $state, $stateParams, userSettingsService) {
        $rootScope.pageTitle = "List User";
        $scope.mList = {};
        $scope.errors = {
            mail : {
                isExists: true,
                message: ''
            }
        };

        userSettingsService.getAll().then(function (response) {
            $scope.mList = response.data;
        }, function (response) {
        });

        $scope.doAdd = function () {
            $state.go('add');
        };
        //added SAVE 
        $scope.doSave = function (eUser, eRequest) {
            userSettingsService.save(eUser, eRequest).then(function (response) {

            }, function (response) {
            });
            $window.location.href = '/Authorisation/Registration/CheckYourEmail';
        };

        $scope.isEmailFree = function () {
            userSettingsService.isEmailFree($scope.mAddEditView.User.Email)
                .then(function (response) {
                    if (response.data.toLowerCase().indexOf('exist') != -1) {
                        $scope.errors.mail = {
                            isExists: true,
                            message: response.data
                        };
                    } else {
                        $scope.errors.mail = {
                            isExists: false,
                            message: response.data
                        };
                    }
                },
                function (error) {

                });
        };


        $scope.doView = function (eUser) {
            $state.go('view', { nID: eUser.ID });
        }

        $scope.doEdit = function (eUser) {
            $state.go('edit', { nID: eUser.ID });
        }

        $scope.doDelete = function (eUser) {
            if (confirm("Confirm delete ?")) {
                userSettingsService.delete(eUser.ID).then(function (response) {
                    $scope.mList = response.data;
                }, function (response) {
                });
            }
        }
    });


