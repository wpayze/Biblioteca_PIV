app.service('libroService',
    [
        '$http',
        'miConfiguracion',
        function ($http, miConfiguracion) {
            function obtenerLibros() {
                return $http.get(miConfiguracion.urlBackend + '/Api/Libro');
            }

            function agregarLibro(nuevoLibro) {
                return $http.post(miConfiguracion.urlBackend + '/Api/Libro', nuevoLibro);
            }

            function editarLibro(libro) {
                return $http.put(miConfiguracion.urlBackend + 'Api/Libro/' + libro.Id, libro);
            }

            function eliminarLibro(libro) {
                return $http.delete(miConfiguracion.urlBackend + 'Api/Libro/' + libro.Id)
            }

            function agregarEditorial(libro, editorial) {
                return $http.put(miConfiguracion.urlBackend + 'api/Libro/' + libro.Id + '/editorial/' + editorial.Id)
            }

            return {
                agregarEditorial: agregarEditorial,
                obtenerLibros: obtenerLibros,
                agregarLibro: agregarLibro,
                editarLibro: editarLibro,
                eliminarLibro: eliminarLibro
            };
        }
    ]
    );