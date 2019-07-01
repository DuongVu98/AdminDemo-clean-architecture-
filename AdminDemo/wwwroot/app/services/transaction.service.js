(function(){
    "use strict";
    
    angular
    .module("commonService")
    .factory("transactionResource",["$resource", getTransactionByUrl])

    function getTransactionByUrl($resource){
        // return $resource("https://localhost:44302/api/admin/transactions/:url", {
        //     query: {
        //         method: "GET",
        //         params: {url: "@url"}
        //     }
        //     // "count": {
        //     //     method: "GET",
        //     //     params: {limit: "@count"}
        //     // }
        // })

        return {
            transactions: $resource("https://localhost:44302/api/admin/transactions/populated-transactions/:limit",{
                query: {
                    method: "GET",
                    params: {limit: "@limit"}
                }
            }),
            count: $resource("https://localhost:44302/api/admin/transactions/count")
        }

        // return $resource("https://localhost:44302/api/admin/transactions/", {
        //     get: {
        //         method: "GET",
        //         params: {limit: "@limit"},
        //         url: "populated-transactions/:limit"
        //     }
        //     // "count": {
        //     //     method: "GET",
        //     //     params: {limit: "@count"}
        //     // }
        // })
    }
}())