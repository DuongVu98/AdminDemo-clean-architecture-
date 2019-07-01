(function(){
    "use strict";

    angular
    .module("admin")
    .config(["$routeProvider", getRouting]);

    function getRouting($routeProvider){

        $routeProvider
        .when("/",{
            templateUrl: "/app/homepage.html"
        })
        .when("/transactions",{
            templateUrl: "/app/transactions/transaction.html"
        })
        .when("/users", {
            templateUrl: "/app/users/user.html"
        })
    }
}());