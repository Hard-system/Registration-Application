angular.module('rootApp', ['ui.router', 'root.controllers', 'root.services'])

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider

        .state('root', {
            url: '/root',
            abstract: true,
            controller: 'rootCtrl'
        })
       
        //changed from list to add-...
        .state('list', {
            url: '/list',
            templateUrl: 'templates/add-edit-view.html',
            controller: 'listCtrl'
        })
    $urlRouterProvider.otherwise('/list');
});
