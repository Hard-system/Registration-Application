﻿angular.module('root.controllers', ['ngSanitize'])

.controller('rootCtrl', function ($scope, $rootScope) {
    $rootScope.pageTitle = "User Settings";
})

.controller('listCtrl', function ($scope, $rootScope, $state, $stateParams, userSettingsService) {
    $rootScope.pageTitle = "List User";
    $scope.mList = {};

  //code for CURRENT USER!!
    userSettingsService.getCurrentUser().then(function (response) {
        $scope.mList = response.data;
    }, function (response) {
    });

    $scope.doAdd = function () {
        $state.go('add');
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
})

.controller('addCtrl', function ($scope, $rootScope, $state, $stateParams, userSettingsService) {
    $rootScope.pageTitle = "Add User";
    $scope.mAddEditView = {};

    $scope.isShowSaveButton = true;

    userSettingsService.getDefault().then(function (response) {
        $scope.mAddEditView = response.data;
    }, function (response) {
    });

    $scope.doSave = function (eUser) {
        userSettingsService.save(eUser).then(function (response) {
            $state.go('list');
        }, function (response) {
        });
    }

    $scope.doCancel = function () {
        $state.go('list');
    }
})

.controller('editCtrl', function ($scope, $rootScope, $state, $stateParams, userSettingsService) {
    $rootScope.pageTitle = "Edit User";
    $scope.mAddEditView = {};

    $scope.isShowSaveButton = true;

    userSettingsService.getByID($stateParams.nID).then(function (response) {
        $scope.mAddEditView = response.data;
    }, function (response) {
    });

    $scope.doSave = function (eUser) {
        userSettingsService.save(eUser).then(function (response) {
            $state.go('list');
        }, function (response) {
        });
    }

    $scope.doSaves = function (eUser) {
        userSettingsService.save1(eUser).then(function (response) {
            $state.go('list');
        }, function (response) {
        });
    }

    $scope.doCancel = function () {
        $state.go('list');
    }
})

.controller('viewCtrl', function ($scope, $rootScope, $state, $stateParams, userSettingsService) {
    $rootScope.pageTitle = "View User";
    $scope.mAddEditView = {};

    $scope.isShowSaveButton = false;

    userSettingsService.getByID($stateParams.nID).then(function (response) {
        $scope.mAddEditView = response.data;
    }, function (response) {
    });

    $scope.doCancel = function () {
        $state.go('list');
    }
});

