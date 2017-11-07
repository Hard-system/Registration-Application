angular.module('root.services', [])

.factory('userSettingsService', function ($http) {
    return {
        getAll: function () {
            return $http.get(sAppContextPath + "Settings/UserSettings/GetAll");
        },
         //code for CURRENT USER!!
        getCurrentUser: function () {
            return $http.get(sAppContextPath + "Settings/UserSettings/GetCurrentUser");
        },


        getByID: function (nID) {
            return $http.get(sAppContextPath + "Settings/UserSettings/GetByID/" + nID);
        },
        getDefault: function () {
            return $http.get(sAppContextPath + "Settings/UserSettings/GetDefault");
        },
        save: function (eUser) {
            var param = {
                eUser: eUser
            };
            return $http.post(sAppContextPath + "Settings/UserSettings/Save", eUser);
        },
        save1: function (eUser) {
            var param = {
                eUser: eUser
            };
            return $http.post(sAppContextPath + "Settings/UserSettings/Save1", eUser);
        },
        delete: function (nID) {
            return $http.delete(sAppContextPath + "Settings/UserSettings/Delete/" + nID);
        }
    };
});
