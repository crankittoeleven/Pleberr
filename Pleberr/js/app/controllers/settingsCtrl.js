app.controller('SettingsCtrl', ['$scope', '$route', '$templateCache', function ($scope, $route, $templateCache) {
    $('.main-header').css('display', 'none');
    $('.settings-frm').submit(function () {
        $.get('../updatesettings/' + localStorage.getItem('id'), {
            firstName: $('.first-txt').val(),
            lastName: $('.last-txt').val(),
            email: $('.email-txt').val(),
            emailRepeat: $('.email-r-txt').val(),
            password: $('.password-txt').val(),
            passwordRepeat: $('.password-r-txt').val(),
            postsPrivacy: $('.posts-privacy').prop('checked'),
            infoPrivacy: $('.info-privacy').prop('checked'),
            friendsPrivacy: $('.friends-privacy').prop('checked'),
            picturesPrivacy: $('.pictures-privacy').prop('checked')
        })
        .done(function (data) {
            $('.settings-result').html(data);
            setTimeout(function () {
                $('.settings-result').html('');
                $templateCache.removeAll();
                $route.reload();
            }, 3000);
        });
        return false;
    });
}]);