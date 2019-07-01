(function(){
    "use strict";
    
    angular
    .module("commonService")
    .factory("transactionResource",["$resource", getTransactionByUrl])

    function getTransactionByUrl($resource){
        return {
            transactions: $resource("https://localhost:44302/api/admin/transactions/populated-transactions/:limit",{
                query: {
                    method: "GET",
                    params: {limit: "@limit"}
                }
            }),
            count: $resource("https://localhost:44302/api/admin/transactions/count")
        }
    }
}())