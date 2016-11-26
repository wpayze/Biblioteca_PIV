app.controller('editorialController', [
    '$scope',
    function ($scope) {
        $scope.editoriales = [
            {
                id: '1',
                nombre: 'Editorial 1'
            },
            {
                id: '2',
                nombre: 'Editorial 2'
            }
        ];
        $scope.editorialActual =
            {
                id: '123',
                nombre: 'Editorial Will'
            }
    }
]);