angular.module('rootApp', ['ui.router', 'root.controllers', 'root.services'])

.config(function ($stateProvider, $urlRouterProvider) {

    $stateProvider

    .state('root', {
        url: '/root',
        abstract: true,
        controller: 'rootCtrl'
    })

    .state('list', {
        url: '/list',
        templateUrl: 'templates/list.html',
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

    .state('edit', {
        url: '/edit/:nID',
        templateUrl: 'templates/add-edit-view.html',
        controller: 'editCtrl'
    })

    $urlRouterProvider.otherwise('/list');
});
