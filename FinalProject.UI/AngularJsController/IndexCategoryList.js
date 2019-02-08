var App = angular.module("App", []);


App.controller("myCtrl", function ($scope, $http) {

    var Success = function (response) {
        $scope.List = response.data;
    }
    var error = function (response) {
        console.log(response);
    }
    $http({
        method: "GET",
        url: "/Home/Kategoriler"
    }).then(Success, error)
});



//İki Şekilde Modül ve Kontroller Oluşturulabilir .... 

//var myApp = angular.module("myApp", []).controller("myContoller", function () {
//   Code....
//})

