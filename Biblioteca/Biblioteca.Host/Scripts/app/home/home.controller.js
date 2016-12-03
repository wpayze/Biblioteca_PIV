app.controller
    (
    'homeController',
    [
        '$scope',
        function ($scope)
        {
            $scope.saludo = "Este es el sitio web de la clase de Programación IV al mando de Lord Ferenck Vargas, utilizando AngularJS, Javascript, HTML y ASP!"

            $(function () {
                if (window.location == window.parent.location) {
                    $('#fullscreen').html('<span class="glyphicon glyphicon-thumbs-up"></span>');
                    $('#fullscreen').attr('href', 'https://github.com/wpayze');
                }
                $('#fullscreen').on('click', function (event) {
                    event.preventDefault();
                    window.parent.location = $('#fullscreen').attr('href');
                });
                $('#fullscreen').tooltip();

                $('.navbar-toggler').on('click', function (event) {
                    event.preventDefault();
                    $(this).closest('.navbar-minimal').toggleClass('open');
                })
            });
        }
    ]
    );
