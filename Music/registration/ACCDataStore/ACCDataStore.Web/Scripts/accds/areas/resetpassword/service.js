angular.module('root.services', [])

.factory('userSettingsService', function ($http) {
    return {
        getAll: function () {
            return $http.get(sAppContextPath + "Settings/UserSettings/GetAll");
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
        delete: function (nID) {
            return $http.delete(sAppContextPath + "Settings/UserSettings/Delete/" + nID);
        }
    };
});
