(function(){
    "use strict";
    
    angular
    .module("commonService")
    .factory("transactionResource",["$resource", getTransactionByUrl])

    function getTransactionByUrl($resource){
        return {
            transactions: $resource("https://localhost:44302/api/test/transactions/:limit",{
                query: {
                    method: "GET",
                    params: {limit: "@limit"}
                }
            }),
            
            search: $resource("https://localhost:44302/api/test/transactions/search/by-user/:string/:limit",{
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