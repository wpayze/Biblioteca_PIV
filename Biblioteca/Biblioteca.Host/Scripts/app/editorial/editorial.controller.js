app.controller('editorialController', [
    '$scope',
    'editorialService',
    function ($scope, editorialService) {
        $scope.editoriales = [];

        $scope.editorialActual =
            {
                Id: '0',
                Nombre: ''
            };

        $scope.accionActual = 'Agregar';
        $scope.mensaje = 'Ingrese un Nuevo Editorial';

        $scope.obtenerEditoriales = function () {
            editorialService.obtenerEditoriales()
            .then(function (response) {
                $scope.editoriales = response.data;
            });
        }
        $scope.guardarEditorial = function ()
        {
            if ($scope.accionActual === 'Agregar')
            {
                editorialService.agregarEditorial($scope.editorialActual)
                            .then(function (response) {
                                $scope.obtenerEditoriales();
                                $scope.limpiar();
                                alert('Editorial Agregada!');
                            })
            }
            else if ($scope.accionActual === 'Editar')
            {
                editorialService.editarEditorial($scope.editorialActual)
            .then(function (response) {
                $scope.obtenerEditoriales();
                $scope.mensaje = 'Modifique el Elemento Seleccionado';
                $scope.limpiar();
                
                alert('Editorial Editada!');
            })
            }
            else if ($scope.accionActual === 'Eliminar') {
                editorialService.eliminarEditorial($scope.editorialActual)
            .then(function (response) {
                $scope.obtenerEditoriales();
                $scope.mensaje = 'Elimine el Elemento Seleccionado';
                $scope.limpiar();
                alert('Editorial Eliminada!');
            }, function (error) {
                alert('Error eliminando editorial!!!')
            });
            }
            
        }
        $scope.limpiar = function () {
            $scope.accionActual = 'Agregar';
            $scope.mensaje = 'Ingrese un Nuevo Editorial';
            $scope.editorialActual = {
                Id: '0',
                Nombre: ''
            }
        }
        $scope.editar = function (editorial) {
            $scope.mensaje = 'Modifique el Elemento Seleccionado';
            $scope.accionActual = 'Editar';
            $scope.editorialActual = JSON.parse(JSON.stringify(editorial));;
        }
        $scope.eliminar = function (editorial)
        {
            $scope.mensaje = 'Elimine el Elemento Seleccionado';
            $scope.accionActual = 'Eliminar';
            $scope.editorialActual = JSON.parse(JSON.stringify(editorial));;
        }

        $scope.obtenerEditoriales();
    }
]);