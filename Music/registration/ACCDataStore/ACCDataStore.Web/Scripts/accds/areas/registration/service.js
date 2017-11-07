angular.module('root.services', []) 

.factory('userSettingsService', function ($http) {
        return {
            getAll: function () {
                return $http.get(sAppContextPath + "Authorisation/Registration/GetAll");
            },
            getByID: function (nID) {
                return $http.get(sAppContextPath + "Authorisation/Registration/GetByID/" + nID);
            },
            getDefault: function () {
                return $http.get(sAppContextPath + "Authorisation/Registration/GetDefault");
            },
            save: function (eUser, eRequest) {
                var param = {
                    eUser: eUser,
                    eRequest: eRequest
                };
                return $http.post(sAppContextPath + "Authorisation/Registration/Save", eUser);
            },
            delete: function (nID) {
                return $http.delete(sAppContextPath + "Authorisation/Registration/Delete/" + nID);
            },
            isEmailFree: function (email) {
                return $http.post(sAppContextPath + "Authorisation/Registration/EmailValidate", { Email: email });
            }

        };
    });

