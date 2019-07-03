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

        transactionResource.transactions.query({ limit: 0 }, data => {
            vm.transactions = data
        })

        transactionResource.count.query(data => {
            // all of transactions (==4)
            transactionsCount = data[0].numberOfAllTransactions
            // number of transactions per page
            numberPerPages = data[0].transactionsPerQuery
            vm.numberPerPages = numberPerPages

            console.log("inside: "+transactionsCount + " - " + vm.numberPerPages)

            //generate number of pages
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

            transactionResource.transactions.query({ limit: limtit }, data => {
                vm.transactions = data
            })
        }

        vm.search = () => {
            console.log("Search !!")
            if(vm.searchString != null){
                transactionResource.search.query({ string: vm.searchString }, data => {
                    vm.transactions = data
                })
            }
        }
    }

}())