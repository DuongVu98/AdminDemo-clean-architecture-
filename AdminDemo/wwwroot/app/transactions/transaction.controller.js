(function () {
    "use strict";

    angular
        .module("admin")
        .controller("transactionController", ["transactionResource", getTransactions])

    function getTransactions(transactionResource) {
        var vm = this

        var transactionsCount
        var numberPerPages
        var numberOfPages

        transactionResource.transactions.get({ limit: 0 }, data => {
            console.log(data)
            vm.transactions = data.transactions
            vm.transactionsCount = data.count
            vm.numberPerPages = data.amountPerPage

            numberPerPages = data.amountPerPage
            transactionsCount = data.count

            if (numberPerPages != 0) {
                if (transactionsCount % numberPerPages != 0) {
                    numberOfPages = Math.floor(transactionsCount / numberPerPages) + 1
                    console.log(numberOfPages)
                } else {
                    numberOfPages = Math.floor(transactionsCount / numberPerPages)
                    console.log(numberOfPages)
                }
                vm.numberOfPages = []
                for (var i = 1; i <= numberOfPages; i++) {
                    vm.numberOfPages.push(i)
                }
            }
        })

        vm.getPage = ($event) => {
            let limtit = $event.target.value
            console.log($event.target.value)

            transactionResource.transactions.get({ limit: limtit }, data => {
                vm.transactions = data.transactions
            })
        }

        vm.search = () => {
            console.log("Search !!")
            console.log(vm.searchString)
            if(vm.searchString != null){
                transactionResource.search.get({ string: vm.searchString, limit: 0 }, data => {
                    vm.transactions = data.transactions
                })
            }else{
                transactionResource.transactions.get({ limit: 0 }, data => {
                    vm.transactions = data.transactions
                })
            }
        }
    }

}())