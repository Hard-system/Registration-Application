angular.module('root.services', [])

.factory('userSettingsService', function ($http) {
    return {
        loginn: function () {
            return $http.get(sAppContextPath + "Login/Login/Logining");
        }
    };
});
