/*************************************************************
 *
 *	Created By: Nguyen Minh Tri - UR81HC
 *  Created Date: 08-04-2015
 *	Description: Angularjs Script to handle any events in client and interact with MVC Controller
 *	
 *	Modified By:  Nguyen Minh Tri - UR81HC
 *	Modified Date: 14-04-2015
 *	Description: edit feature
 *
 *  Modified By:  Nguyen Minh Tri - UR81HC
 *	Modified Date: 20-04-2015
 *	Description: add answers feature
 *
 *************************************************************/


angular.module("GlobalModule").controller("questionController", QuestionController);
QuestionController.$inject = ['$scope', '$http', '$location', '$q', 'modalService'];

function QuestionController($scope, $http, $location, $q, modalService) {

    $scope.$scope = $scope;
    $scope.Answers = [{ Content: '0', Add: true, Remove: false, Order: 0, IsAnswer: false }];
    $scope.SearchInput = [];
    $scope.IsShowButtonForEdit = false;

    $scope.CurrentQuestionModel = { Code: '', Status: 'UnSubmit', CategoryId: '', Type: '', CreatedDateString: '', LevelQuestionId: '', ContentQuestion: '', TagArray: [] };

    $scope.TypesData = [];
    $scope.LoadTypeData = function () {
        var deferred = $q.defer();
        $http.get($scope.AppPath + "Question/GetTypes").success(function (data) {
            $scope.TypesData = data;
            deferred.resolve(data);
        }).error(deferred.reject);
        return deferred.promise;
    };

    $scope.CategoriesData = [];
    $scope.LoadCategoryData = function () {
        var deferred = $q.defer();
        $http.get($scope.AppPath + "Question/GetCategories").success(function (data) {
            $scope.CategoriesData = data;
            deferred.resolve(data);
        }).error(deferred.reject);
        return deferred.promise;
    };

    $scope.LevelsData = [];
    $scope.LoadLevelsData = function () {
        var deferred = $q.defer();
        $http.get($scope.AppPath + "Question/GetLevels").success(function (data) {
            $scope.LevelsData = data;
            deferred.resolve(data);
        }).error(deferred.reject);
        return deferred.promise;
    };

    // Datepicker
    $scope.OpenCreatedDateCalendar = function ($event) {
        $event.preventDefault();
        $event.stopPropagation();
        $scope.opened = true;
    };
    $scope.format = 'dd/MM/yyyy';
    $scope.dateOptions = {
        formatYear: 'yy',
        startingDay: 1
    };


    //Define datasource for questions grid
    $scope.myData = [];
    $scope.gridOptions = {};
    $scope.deleteCellTemplate = '<button ng-click="getExternalScopes().DeleteRow(row.entity)" class="btn btn-danger btn-xs"><i class="fa fa-trash"/></button> ';
    $scope.detailsCellTemplate = '<button ng-click="getExternalScopes().GetDetails(row.entity)" class="btn btn-primary btn-xs"><i class="fa fa-pencil-square-o"/></button> ';
    $scope.submitCellTemplate = '<button ng-click="getExternalScopes().Submit(row.entity)" class="btn btn-info btn-xs"><i class="fa fa-envelope"/></button> ';

    //headerCellTemplate: '<div title="Tooltip Content">Name</div>'
    $scope.gridOptions.columnDefs = [
  	      { name: 'Code', displayName: 'Code', width: '5%' },
  	      { name: 'ContentQuestion', displayName: 'Question Content', width: '62%' },
          { name: 'Status', displayName: 'Status', width: '10%' },
          { name: '_edit', displayName: 'Edit', cellTemplate: $scope.detailsCellTemplate, width: '7%', },
          { name: '_submit', displayName: "Submit", cellTemplate: $scope.submitCellTemplate, width: '7%' },
          { name: '_delete', displayName: "Delete", cellTemplate: $scope.deleteCellTemplate, width: '7%' }

    ];
    $scope.gridOptions.paginationPageSizes = [25, 50, 75, 100];
    $scope.gridOptions.paginationPageSize = 25;
    $scope.gridOptions.data = "myData";
    $scope.gridOptions.enableFiltering = false;


    $scope.LoadQuestionData = function () {
        var deferred = $q.defer();
        $http.get("Question/GetQuestions").success(function (data) {
            $scope.myData = data;
            deferred.resolve(data);
        }).error(deferred.reject);
        return deferred.promise;
    };


    $scope.LoadData = function () {
        $http.get("Question/GetQuestions").success(function(data) {
        });
        //$scope.LoadTypeData().then($scope.LoadCategoryData).then($scope.LoadLevelsData).then($scope.LoadQuestionData).then(function () {
        //    waitDialog.Hide();
        //});
    };

    $scope.TmpDataForEdit = { Code: '', Status: 'UnSubmit', CategoryId: '', Type: '', CreatedDateString: '', LevelQuestionId: '', ContentQuestion: '', TagArray: [] };
    $scope.CurrentIndex = -1;
    $scope.GetDetails = function (row) {
        $scope.CancelEdit();
        $scope.IsShowButtonForEdit = true;
        $scope.TmpDataForEdit = angular.copy(row);
        $scope.CurrentQuestionModel = row;

        //modalService.ShowModal();
    };


    $scope.CreateQuestion = function () {

    };

    $scope.CancelEdit = function () {
        $scope.IsShowButtonForEdit = false;
        $scope.myData[$scope.CurrentIndex] = $scope.TmpDataForEdit;
        $scope.CurrentQuestionModel = {};
    };

    $scope.SaveEdit = function () {
        $scope.ShowModal(null, null, { Title: "Confirm", Content: "Would you like to save?", ButtonOk: "OK", ButtonCancel: "Cancel", Size: 'sm', Template: '', Controller: '' });
    };

    $scope.DeleteRow = function (row) {
        $scope.ShowModal(null, null, { Title: "Confirm", Content: "Would you like to delete?", ButtonOk: "OK", ButtonCancel: "Cancel", Size: 'sm', Template: '', Controller: '' });
    };

    $scope.Submit = function (row) {
        $scope.ShowModal(null, null, { Title: "Confirm", Content: "Would you like to submit ?", ButtonOk: "OK", ButtonCancel: "Cancel", Size: 'sm', Template: '', Controller: '' });
    };




    // Handle actions Question Details in Modal
    angular.module("GlobalModule").controller("detailQuestionModalController", DetailQuestionModalController);
    DetailQuestionModalController.$inject = ['$scope', '$modalInstance', '$interval', 'passData'];
    function DetailQuestionModalController($scope, $modalInstance, $interval, passData) {

        $scope.$scope = $scope;



        //Get index of item in array by its Order
        $scope.GetIndexOf = function (arr, item) {
            for (var i = 0; i < arr.length; i++) {

                if (arr[i].Order == item.Order) {
                    return i;
                }
            }
            return -1;
        };

        $scope.AddInputAnswer = function (order) {
            $scope.Answers[order].Add = false;
            $scope.Answers.push({ Content: $scope.Answers.length, Add: true, Remove: true, Order: $scope.Answers.length, IsAnswer: false });
        };

        $scope.RemoveInputAnswer = function (order) {
            $scope.Answers.splice($scope.GetIndexOf(order), 1);
            $scope.Answers[$scope.Answers.length - 1].Add = true;
        };


        $scope.ok = function () {
            //Close and Pass return result
            $modalInstance.close('returnData');
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('returnfalse');
        };
    }

}