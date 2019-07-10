(function(){
    "use strict";

    angular
    .module("admin")
    .controller("userController",["userResource", usersProcessing]);

    function usersProcessing(userResource) {
        var vm = this

        initPage(userResource, vm)

        vm.getInitPage = () => {
            initPage(userResource, vm)
            vm.searchString = null;
        }

        vm.getPage = ($event) => {
            let limit = $event.target.value
            console.log($event.target.value)

            if(vm.searchString != null){
                getUsersSearch(userResource, vm, limit)
            }
            else{
                userResource.users.get({ limit: limit }, data => {
                    vm.users = data.users
                })
            }
        }

        vm.search = () => {
            console.log("Search !!")
            console.log(vm.searchString)
            if(vm.searchString != null){
                getUsersSearch(userResource, vm, 0)
            }else{
                getUsersQuery(userResource, vm, 0)
            }
        }
    }

    let initPage = (resource, scope) => {
        getUsersQuery(resource, scope, 0)
    }

    let getUsersQuery = (resource, scope, limit) => {
        resource.users.get({ limit: limit }, data => {
            scope.users = data.users
            scope.usersCount = data.count
            scope.numberPerPages = data.amountPerPage

            generatePagesList(scope, scope.numberPerPages, scope.usersCount)
        })
    }

    let getUsersSearch = (resource, scope, limit) => {
        resource.search.get({ string: scope.searchString, limit: limit }, data => {
            scope.users = data.users
            scope.usersCount = data.count
            scope.numberPerPages = data.amountPerPage

            generatePagesList(scope, scope.numberPerPages, scope.usersCount)
        })
    }

    let generatePagesList = (scope, numberPerPage, usersCount) => {
        var numberOfPages
        if (numberPerPage != 0) {
            if (usersCount % numberPerPage != 0) {
                numberOfPages = Math.floor(usersCount / numberPerPage) + 1
                console.log(numberOfPages)
            } else {
                numberOfPages = Math.floor(usersCount / numberPerPage)
                console.log(numberOfPages)
            }
            scope.numberOfPages = []
            for (var i = 1; i <= numberOfPages; i++) {
                scope.numberOfPages.push(i)
            }
        }
    }
}())