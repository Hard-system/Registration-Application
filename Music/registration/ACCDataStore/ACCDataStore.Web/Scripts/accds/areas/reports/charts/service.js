angular.module('root.services', [])

.factory('homeService', function ($http) {
    return {
        getChartsData: function () {
            return $http.get(sAppContextPath + "Reports/Charts/GetChartsData");
        }
    };
});
