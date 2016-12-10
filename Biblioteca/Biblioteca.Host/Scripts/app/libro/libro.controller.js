app.controller('libroController', [
    '$scope',
    'libroService',
    'editorialService',
    function ($scope, libroService, editorialService) {
        $scope.libros = [];
        $scope.editoriales = [];
        $scope.libroActual =
            {
                Id: '0',
                Nombre: '',
                Ano: '',
            };

        $scope.editorialSeleccionada = undefined;
        $scope.accionActual = 'Agregar';
        $scope.mensaje = 'Ingrese un Nuevo Libro';

        $scope.obtenerEditoriales = function () {
            editorialService.obtenerEditoriales()
            .then(function (response)
            {
                $scope.editoriales = response.data;
            })
        }

        $scope.obtenerLibros = function () {
            libroService.obtenerLibros()
            .then(function (response) {
                $scope.libros = response.data;
            });
        }
        $scope.guardarLibro = function () {
            if ($scope.accionActual === 'Agregar') {
                libroService.agregarLibro($scope.libroActual)
                            .then(function (response) {
                                libroService.agregarEditorial(response.data, $scope.editorialSeleccionada)
                                .then(function (response2) {
                                    $scope.obtenerLibros();
                                    $scope.limpiar();
                                    alert('Libro Agregado!')
                                });
                            })
            }
            else if ($scope.accionActual === 'Editar') {
                libroService.editarLibro($scope.libroActual)
            .then(function (response) {
                libroService.agregarEditorial(response.data, $scope.editorialSeleccionada)
                                .then(function (response2) {
                                    $scope.obtenerLibros();
                                    $scope.limpiar();
                                    alert('Libro Editado!')
                                });
            })
            }
            else if ($scope.accionActual === 'Eliminar') {
                libroService.eliminarLibro($scope.libroActual)
            .then(function (response) {
                $scope.obtenerLibros();
                $scope.mensaje = 'Elimine el Elemento Seleccionado';
                $scope.limpiar();
                alert('Libro Eliminado!');
            })
            }


        }
        $scope.limpiar = function () {
            $scope.accionActual = 'Agregar';
            $scope.mensaje = 'Ingrese un Nuevo Libro';
            $scope.libroActual = {
                Id: '0',
                Nombre: '',
                Ano: '',
            }
            $scope.editorialSeleccionada = undefined;
        }
        $scope.editar = function (libro) {
            $scope.mensaje = 'Modifique el Elemento Seleccionado';
            $scope.accionActual = 'Editar';
            $scope.libroActual = JSON.parse(JSON.stringify(libro));;
            $scope.editorialSeleccionada = undefined;
            $scope.editorialSeleccionada = $scope.editoriales.find(function (editorial) {
                return editorial.Id === libro.Editorial.Id;
            })

        }
        $scope.eliminar = function (libro) {
            $scope.mensaje = 'Elimine el Elemento Seleccionado';
            $scope.accionActual = 'Eliminar';
            $scope.libroActual = JSON.parse(JSON.stringify(libro));;
        }

        $scope.obtenerEditoriales();
        $scope.obtenerLibros();
    }
]);