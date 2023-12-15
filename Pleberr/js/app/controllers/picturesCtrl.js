app.controller('PicturesCtrl', ['$scope', '$templateCache', function ($scope, $templateCache) {
    $('.main-header').css('display', 'none');
    $('.delete-img').click(function (e) {
        e.stopPropagation();
        var elem = $(this);
        $.post('../deletepicture/' + localStorage.getItem('id'), {
            name: elem.parent().parent().attr('data-file-name')
        }).done(function () {
            elem.parent().parent().fadeOut(200, function () {
                $templateCache.removeAll();
            });
        });
    });
}]);