angular.module('rootApp', ['ui.router', 'root.controllers', 'root.services'])

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider

    .state('root', {
        url: '/root',
        abstract: true,
        controller: 'rootCtrl'
    })

    .state('home', {
        url: '/home',
        templateUrl: 'templates/home.html',
        controller: 'homeCtrl'
    })

    $urlRouterProvider.otherwise('/home');
});
