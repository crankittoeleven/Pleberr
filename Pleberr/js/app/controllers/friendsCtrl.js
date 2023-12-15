app.controller('FriendsCtrl', ['$scope', '$route', '$templateCache', function ($scope, $route, $templateCache) {
    $('.main-header').css('display', 'none');
    $('.accept-request').click(function () {
        var elem = $(this);
        $.post('../addfriend/' + localStorage.getItem('pageId'), {
            from: elem.parent().attr('data-from'),
            add: true
        })
        .done(function () {
            elem.parent().fadeOut(200, function () {
                $templateCache.removeAll();
                $route.reload();
            });
        });
    });
    $('.decline-request').click(function () {
        var elem = $(this);
        $.post('../addfriend/' + localStorage.getItem('pageId'), {
            from: elem.parent().attr('data-from'),
            add: false
        })
        .done(function () {
            elem.parent().fadeOut(200, function () {
                $templateCache.removeAll();
                $route.reload();
            });
        });
    });
    $('.delete-friend').click(function (e) {
        e.stopPropagation();
        var elem = $(this);
        $.post('../deletefriend/' + localStorage.getItem('id'), {
            friend: elem.parent().parent().attr('data-id')
        }).done(function () {
            elem.parent().parent().fadeOut(200, function () {
                $templateCache.removeAll();
            });
        });
    });
}]);