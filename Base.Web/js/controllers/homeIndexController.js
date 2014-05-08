(function () {
    'use strict';

    var controllerId = 'homeIndexController';

    // TODO: replace app with your module name
    angular.module('sampleApp').controller(controllerId,
        ['$scope', homeIndexController]);

    function homeIndexController($scope) {
        $scope.title = 'Sample App';
        $scope.activate = activate;

        function activate() { }
    }
})();
