angular.module('root.controllers', ['ngSanitize'])

    .controller('rootCtrl', function ($scope, $rootScope) {
        $rootScope.pageTitle = "User Settings";
    })
    .controller('Login', function ($scope, $window) {
        $window.location = 'http://www.google.com'
    })

    .controller('listCtrl', function ($scope, $window, $rootScope, $state, $stateParams, userSettingsService) {
        $rootScope.pageTitle = "List User";
        $scope.mList = {};
        // added the login function
        $scope.doIsValidUser = function (user, pass){
            userSettingsService.Logining(user, pass).then(function (response) {
                $scope.mList = response.data;
            }, function (response) {
            });
        }
    
        $scope.doAdd = function () {
            $state.go('add');
        }

        //added SAVE 
        $scope.doSave = function (eUser, eRequest) {
            userSettingsService.save(eUser, eRequest).then(function (response) {

            }, function (response) {
            });
            $window.location.href = '/';
        }
        $scope.redirect = function () {
            window.location = '/home';
        }


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
