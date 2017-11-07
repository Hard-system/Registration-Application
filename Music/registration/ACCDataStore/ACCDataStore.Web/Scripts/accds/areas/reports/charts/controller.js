angular.module('root.controllers', ['highcharts-ng'])

.controller('rootCtrl', function () {
})

.controller('homeCtrl', function ($scope, homeService) {
    $scope.mHome = {};

    homeService.getChartsData().then(function (response) {
        $scope.mHome = response.data;
    }, function (response) {
    });
});

