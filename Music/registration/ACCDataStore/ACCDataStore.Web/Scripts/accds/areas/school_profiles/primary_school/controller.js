angular.module('root.controllers', ['ngSanitize', 'ui.select', 'highcharts-ng', 'datatables'])

.controller('rootCtrl', function ($scope, $rootScope) {
})

.controller('indexCtrl', function ($scope, $rootScope, $state, $stateParams, indexService) {
    $scope.mIndex = {};

    indexService.getCondition().then(function (response) {
        $scope.mIndex.bShowContent = false;
        $scope.mIndex = response.data;
    }, function (response) {
    });

    $scope.doGetData = function () {
        var listSchoolID = [];
        angular.forEach($scope.mIndex.ListSchoolSelected, function (item, key) { // create list of selected school's id to send via http get
            listSchoolID.push(item.SchoolID);
        });
        indexService.getSchoolData(listSchoolID).then(function (response) {
            $scope.mIndex = response.data;
            $scope.mIndex.bShowContent = true;
        }, function (response) {
        });
    }
});

