var TestApp = angular.module('HelpDeskTicketCount', []);

TestApp.controller('FrontPage', function ($scope, $http) {
    $scope.NewIncident = null;
    $scope.NewRequest = null;

    $http.get("API/Ticket")
        .success(function (data, status, header, config) {
            $scope.request = data.requests;
            $scope.incidents = data.incidents;
            $scope.update = data.DaysAgo;
        });
    $scope.UpdateData = function () {
        $scope.request = $scope.NewRequest;
        $scope.incidents = $scope.NewIncident;

        $scope.NewIncident = null;
        $scope.NewRequest = null;

        var data = { requests: $scope.request, incidents: $scope.incidents};
        $http.post("API/Ticket", data)
        .success(function (data, status, headers) {
            $http.get("API/Ticket")
            .success(function (data, status, header, config) {
            $scope.request = data.requests;
            $scope.incidents = data.incidents;
            $scope.update = data.DaysAgo;
        });
        });
    };

});