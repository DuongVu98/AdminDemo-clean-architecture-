(function(){
    "use strict";
    
    angular
    .module("commonService")
    .factory("transactionResource",["$resource", getTransactionByUrl])

    function getTransactionByUrl($resource){
        return $resource("https://localhost:44302/api/admin/populated-transactions")
    }
}())