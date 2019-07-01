(function(){
    "use strict";

    angular
    .module("admin")
    .controller("transactionController",["transactionResource", getTransactions])

    function getTransactions(transactionResource){
        var vm = this
        transactionResource.query(function(data){
            vm.transactions = data
        })
    }
}())