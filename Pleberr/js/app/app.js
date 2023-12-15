var app = angular.module('pleberr', ['ngRoute', 'ngResource']);
app.config(['$routeProvider', function ($routeProvider) {
    var id;
    if (localStorage.getItem('pageId') === null) {
        id = localStorage.getItem('id');
    } else {
        id = localStorage.getItem('pageId');
    }
    $routeProvider.when('/', {
        templateUrl: '/home/home/' + localStorage.getItem('pageId'),
        controller: 'MainCtrl'
    })
    .when('/feed', {
        templateUrl: '../feed/' + localStorage.getItem('pageId'),
        controller: 'FeedCtrl'
    })
    .when('/friends', {
        templateUrl: '../friends/' + localStorage.getItem('pageId'),
        controller: 'FriendsCtrl'
    })
    .when('/pictures', {
        templateUrl: '../pictures/' + localStorage.getItem('pageId'),
        controller: 'PicturesCtrl'
    })
    .when('/settings', {
        templateUrl: '../settings/' + localStorage.getItem('pageId'),
        controller: 'SettingsCtrl'
    })
    .when('/messages', {
        templateUrl: '../messages/' + localStorage.getItem('pageId'),
        controller: 'MessagesCtrl'
    })
    .otherwise({
        redirectTo: '/'
    });
}]);
app.run(function ($rootScope, $route, $templateCache) {
    $('.post').find('button').click(function () {
        $.post("../post", {
            owner: localStorage.getItem('id'),
            author: localStorage.getItem('id'),
            dateCreated: (new Date().getYear() + 1900) + '-' + (new Date().getMonth() + 1) + '-' + new Date().getDate() + ' ' + new Date().getHours() + ':' + new Date().getMinutes() + ':' + new Date().getSeconds(),
            content: $('.post').find('textarea').val().replace("'", '&rsquo;').replace('#', '&#35;').replace('+', '&#43;'),
            type: 'text'
        })
        .done(function () {
            $('.post').toggle();
            $('.overlay').toggle();
            $templateCache.removeAll();
            $route.reload();
        });
    });
    $('.video').find('button').click(function () {
        $.post("../post", {
            owner: localStorage.getItem('id'),
            author: localStorage.getItem('id'),
            dateCreated: (new Date().getYear() + 1900) + '-' + (new Date().getMonth() + 1) + '-' + new Date().getDate() + ' ' + new Date().getHours() + ':' + new Date().getMinutes() + ':' + new Date().getSeconds(),
            content: '<iframe style="height:278px;width:100%;max-width:100%;border:0;" frameborder="0" src="https://www.youtube.com/embed/' + $('.video').find('input').val().replace('https://www.youtube.com/watch?v=', '') + '?hl=en&amp;autoplay=0&amp;cc_load_policy=0&amp;loop=0&amp;iv_load_policy=0&amp;fs=1&amp;showinfo=0"></iframe>',
            type: 'video'
        })
        .done(function () {
            $('.video').toggle();
            $('.overlay').toggle();
            $templateCache.removeAll();
            $route.reload();
        });
    });
    $('#file-selectImg').change(function () {
        $('.preloader').css('width', '100%');
        $('#file-formImg').submit();
        setTimeout(function () {
            $('.picture').toggle();
            $('.overlay').toggle();
            $('.preloader').hide();
            $('.preloader').css('width', 0);
            $templateCache.removeAll();
            $route.reload();
        }, 8000);
    });
});