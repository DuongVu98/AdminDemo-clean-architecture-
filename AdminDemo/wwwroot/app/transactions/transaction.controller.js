(function(){
    "use strict";

    angular
    .module("admin")
    .controller("transactionController",["transactionResource", getTransactions])

    function getTransactions(transactionResource){
        var vm = this

        let pageNumber=""
        vm.getPage = ($event) => {
            pageNumber = $event.target.value
            console.log($event.target.value)

            transactionResource.transactions.query({limit: pageNumber}, data => {
                vm.transactions = data
            })
        }

        transactionResource.transactions.query({limit: 1}, data => {
            vm.transactions = data
        })

        transactionResource.count.query(data => {
            vm.count = data
            console.log(data)
        })
    }


}())