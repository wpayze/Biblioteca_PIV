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
                $scope.limpiar();
                alert('Editorial Editada!');
            })
            }

            
        }
        $scope.limpiar = function () {
            $scope.accionActual = 'Agregar';
            $scope.editorialActual = {
                Id: '0',
                Nombre: ''
            }
        }
        $scope.editar = function (editorial) {
            $scope.accionActual = 'Editar';
            $scope.editorialActual = editorial;
        }

        $scope.obtenerEditoriales();
    }
]);