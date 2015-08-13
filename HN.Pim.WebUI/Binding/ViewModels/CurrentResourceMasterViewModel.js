appMainModule.controller("CurrentResourceMasterViewModel", function ($scope, $http, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.currentResources = [];
    $scope.init = false; // used so view doesn't sit on top

    $scope.loadCurrentResources = function () {
        viewModelHelper.apiGet('api/resourcemaster/availableresourcemaster', null,
            function (result) {
                for (var i = 0; i < result.data.length; i++) {
                    result.data['CancelRequest'] = false;
                    $scope.currentResources = result.data;
                }
                $scope.init = true;
            });
    }

    $scope.loadCurrentResources();
});