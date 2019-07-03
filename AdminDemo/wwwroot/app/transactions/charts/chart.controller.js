(function(){
    "use strict"
    
    angular
    .module("admin", ["chart.js"])
    .controller("PolarAreaCtrl", function ($scope) {
        $scope.labels = ["Download Sales", "In-Store Sales", "Mail-Order Sales", "Tele Sales", "Corporate Sales"];
        $scope.data = [300, 500, 100, 40, 120];
    });
}())
