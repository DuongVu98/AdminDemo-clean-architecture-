(function(){
    "use strict";
    
    angular
    .module("commonService")
    .factory("userResource",["$resource", getUserByUrl])

    function getUserByUrl($resource){
        return {
            users: $resource("https://localhost:44302/api/admin/users/:limit",{
                query: {
                    method: "GET",
                    params: {limit: "@limit"}
                }
            }),
            
            search: $resource("https://localhost:44302/api/admin/users/search/by-username/:string/:limit",{
                query: {
                    method: "GET",
                    params: 
                    {
                        string: "@string",
                        limit: '@limit'
                    }
                }
            })
        }
    }
}())