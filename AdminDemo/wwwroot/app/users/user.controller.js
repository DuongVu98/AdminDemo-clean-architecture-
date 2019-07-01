(function(){
    "use strict";

    angular
    .module("admin")
    .controller("userController",["userResource", getUsers]);

    function getUsers(userResource){
        var vm = this
        userResource.query(function(data){
            vm.users = data
        })
    }
}())