angular.module('root.controllers', ['ngSanitize'])

    .controller('rootCtrl', function ($scope, $rootScope) {
        $rootScope.pageTitle = "User Settings";
    })

    
    .controller('listCtrl', function ($scope, $window, $rootScope, $state, $stateParams, userSettingsService) {
        $rootScope.pageTitle = "List User";
        
    
        //added Sendemail
        $scope.doSendEmail = function (eUser) {
            userSettingsService.sendemail(eUser).then(function (response) {

            }, function (response) {
            });
            $window.location.href = '/ForgotPassword/ForgotPassword/CheckYourEmail';
        }

        //added Save
        $scope.doSave = function (email) {
            userSettingsService.save(email).then(function (response) {

            }, function (response) {
            });
            $window.location.href = '/ForgotPassword/ForgotPassword/PasswordSuccess';
        }
        
    });