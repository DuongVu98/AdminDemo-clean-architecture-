(function () {
    "use strict";

    angular
        .module("admin")
        .controller("transactionController", ["transactionResource", getTransactions])

    function getTransactions(transactionResource) {
        var vm = this

        initPage(transactionResource, vm)

        vm.getPage = ($event) => {
            let limit = $event.target.value
            console.log($event.target.value)

            if(vm.searchString != null){
                getTransactionsSearch(transactionResource, vm, limit)
            }
            else{
                transactionResource.transactions.get({ limit: limit }, data => {
                    vm.transactions = data.transactions
                })
            }
            
        }

        vm.search = () => {
            console.log("Search !!")
            console.log(vm.searchString)
            if(vm.searchString != null){
                getTransactionsSearch(transactionResource, vm, 0)
            }else{
                getTransactionsQuery(transactionResource, vm, 0)
            }
        }
    }

    function initPage(resource, scope){
        getTransactionsQuery(resource, scope, 0)
    }

    function getTransactionsQuery(resource, scope, limit){
        resource.transactions.get({ limit: limit }, data => {
            scope.transactions = data.transactions
            scope.transactionsCount = data.count
            scope.numberPerPages = data.amountPerPage

            generatePagesList(scope, scope.numberPerPages, scope.transactionsCount)
        })
    }

    function getTransactionsSearch(resource, scope, limit){
        resource.search.get({ string: scope.searchString, limit: limit }, data => {
            scope.transactions = data.transactions
            scope.transactionsCount = data.count
            scope.numberPerPages = data.amountPerPage

            generatePagesList(scope, scope.numberPerPages, scope.transactionsCount)
        })
    }

    function generatePagesList(scope, numberPerPage, transactionsCount){
        var numberOfPages
        if (numberPerPage != 0) {
            if (transactionsCount % numberPerPage != 0) {
                numberOfPages = Math.floor(transactionsCount / numberPerPage) + 1
                console.log(numberOfPages)
            } else {
                numberOfPages = Math.floor(transactionsCount / numberPerPage)
                console.log(numberOfPages)
            }
            scope.numberOfPages = []
            for (var i = 1; i <= numberOfPages; i++) {
                scope.numberOfPages.push(i)
            }
        }
    }
}())