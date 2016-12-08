app.controller('libroController', [
    '$scope',
    'libroService',
    function ($scope, libroService) {
        $scope.libros = [];

        $scope.libroActual =
            {
                Id: '0',
                Nombre: '',
                Año: '0000',
                Editorial: '',
                Autores: ''
            };

        $scope.accionActual = 'Agregar';
        $scope.mensaje = 'Ingrese un Nuevo Libro';

        $scope.obtenerLibros = function () {
            libroService.obtenerLibros()
            .then(function (response) {
                $scope.libros = response.data;
            });
        }
        $scope.guardarLibro = function () {
            if ($scope.accionActual === 'Agregar') {
                editorialService.agregarLibro($scope.libroActual)
                            .then(function (response) {
                                $scope.obtenerLibros();
                                $scope.limpiar();
                                alert('Libro Agregado!');
                            })
            }
            else if ($scope.accionActual === 'Editar') {
                libroService.editarLibro($scope.libroActual)
            .then(function (response) {
                $scope.obtenerLibros();
                $scope.mensaje = 'Modifique el Elemento Seleccionado';
                $scope.limpiar();

                alert('Libro Editado!');
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
                Año: '0000',
                Editorial: '',
                Autores: ''
            }
        }
        $scope.editar = function (editorial) {
            $scope.mensaje = 'Modifique el Elemento Seleccionado';
            $scope.accionActual = 'Editar';
            $scope.libroActual = JSON.parse(JSON.stringify(libro));;
        }
        $scope.eliminar = function (libro) {
            $scope.mensaje = 'Elimine el Elemento Seleccionado';
            $scope.accionActual = 'Eliminar';
            $scope.libroActual = JSON.parse(JSON.stringify(libro));;
        }

        $scope.obtenerLibros();
    }
]);