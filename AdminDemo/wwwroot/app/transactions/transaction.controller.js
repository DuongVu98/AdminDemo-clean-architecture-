(function () {
    "use strict";

    angular
        .module("admin")
        .controller("transactionController", ["transactionResource", getTransactions])

    function getTransactions(transactionResource) {
        var vm = this
        let transactionsCount = ""
        let numberPerPages = 2
        let numberOfPages
        let pageNumber = ""

        vm.getPage = ($event) => {
            pageNumber = $event.target.value
            console.log($event.target.value)

            transactionResource.transactions.query({ limit: pageNumber }, data => {
                vm.transactions = data
            })
        }

        transactionResource.transactions.query({ limit: 1 }, data => {
            vm.transactions = data
        })

        transactionResource.count.query(data => {
            transactionsCount = data[0].thiscount
            if(transactionsCount % numberPerPages != 0){
                numberOfPages = Math.floor(transactionsCount / numberPerPages) + 1
            }else{
                numberOfPages = Math.floor(transactionsCount / numberPerPages)
            }
            
            let pagesList = document.getElementById("pages-list")
            for (var i = 1; i <= numberOfPages; i++) {
                let html = '<a class="ui circular label" ng-value="'+i+'" ng-click="vm.getPage($event)">'+i+'</a>'
                var child = document.createElement('td')
                child.innerHTML = html
                // child = child.firstChild
                document.getElementById("pages-list").appendChild(child)
            }
        })

    }


}())