

angular.module('root.services', [])

.factory('userSettingsService', function ($http) {
    return {
        getAll: function () {
            return $http.get(sAppContextPath + "ForgotPassword/ForgotPassword/GetAll");
        },

        getAll2: function () {
            return $http.get(sAppContextPath + "ForgotPassword/ForgotPassword/GetAll2");
        },

        sendemail: function (eUser) {
            var param = {
                eUser: eUser
              
            };
            return $http.post(sAppContextPath + "ForgotPassword/ForgotPassword/SendEmail", eUser);
        },
        save: function (email) {
            var param = {
                email: email
                
            };
            return $http.post(sAppContextPath + "ForgotPassword/ForgotPassword/Save", eUser);
        }
       

    };
});


