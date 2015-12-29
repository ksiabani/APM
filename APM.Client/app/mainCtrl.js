(function () {
    'use strict';

    angular
        .module('productManagement')
        .controller('MainCtrl', ['userAccount', MainCtrl]);

    function MainCtrl(userAccount) {
        var vm = this;
        vm.isLoggedIn = false;
        vm.message = '';
        vm.userData = {
            userName: '',
            email: '',
            password: '',
            comfirmPassword: ''
        }

        vm.registerUser = function () {   
            vm.userData.confirmPassword = vm.userData.password;

            userAccount.registerUser(vm.userData, function (data) {
                vm.confirmPassword = '';
                vm.message = '... Registration succesful';
                vm.login();
            },
            function (response){
                vm.isLoggedIn = false;
                vm.message = response.statusText + '\r\n';
                if (response.data.exceptionMessage) {
                    vm.message += response.data.exceptionMessage;
                }
                // validation errors
                if (response.data.modelState) {
                    for (var key in response.data.modelState) {
                        vm.message += response.data.modelState[key] + 'r\n';
                    }
                }
            });
        };

        vm.login = function () {

        };
    }
})();