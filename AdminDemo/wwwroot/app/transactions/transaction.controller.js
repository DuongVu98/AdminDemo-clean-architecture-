(function(){
    "use strict";

    angular
    .module("admin")
    .controller("transactionController",["transactionResource", getTransactions])

    function getTransactions(transactionResource, $http){
        var vm = this

        transactionResource.transactions.query({limit: 1}, data => {
            vm.transactions = data
        })

        transactionResource.count.query(data => {
            vm.count = data
            console.log(data)
        })
    }
}())