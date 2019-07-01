(function(){
    "use strict";
    
    angular
    .module("commonService")
    .factory("userResource",["$resource", getUserByUrl])

    function getUserByUrl($resource){
        return $resource("https://localhost:44302/api/admin/users/populated-users")
    }
}())