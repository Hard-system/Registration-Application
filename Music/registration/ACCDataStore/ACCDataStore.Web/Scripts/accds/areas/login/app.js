angular.module('rootApp', ['ui.router', 'root.controllers', 'root.services'])

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider

        .state('root', {
            url: '/root',
            abstract: true,
            controller: 'rootCtrl'
        })
        //added state home

        .state('home', {
            url: '/home',
            templateUrl: 'templates/home.html',
            controller: 'Registration'
        })
        
        //changed from list to add-...
        .state('list', {
            url: '/list',
            templateUrl: 'templates/add-edit-view.html',
            controller: 'listCtrl'
        })

        .state('add', {
            url: '/add',
            templateUrl: 'templates/add-edit-view.html',
            controller: 'addCtrl'
        })

        .state('view', {
            url: '/view/:nID',
            templateUrl: 'templates/add-edit-view.html',
            controller: 'viewCtrl'
        })

    $urlRouterProvider.otherwise('/list');
});
