angular.module('root.services', [])

.factory('indexService', function ($http) {
    return {
        getCondition: function () {
            return $http.get(sAppContextPath + "SchoolProfiles/PrimarySchool/GetCondition");
        },
        getData: function (listSchoolID) {
            return $http.get(sAppContextPath + "SchoolProfiles/PrimarySchool/GetData", { params: { "listSchoolID": listSchoolID } });
        },
        getSchoolData: function (listSchoolID) {
            return $http.get(sAppContextPath + "SchoolProfiles/PrimarySchool/GetSchoolData", { params: { "listSchoolID": listSchoolID } });
        }
    };
});
