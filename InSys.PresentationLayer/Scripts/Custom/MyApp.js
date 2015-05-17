/* *************************************************************
 *
 *	Created By: Nguyen Minh Tri - UR81HC
 *  Created Date: 03-04-2015
 *	Description: Global script to define basic functions and root angularjs module
 *	
 *	Modified By: Nguyen Minh Tri - UR81HC
 *	Modified Date: 08-04-2015
 *	Description: add modal in rootScope
 *
 *************************************************************/

(function () {

    'use strict';

    angular.module("GlobalModule", ['ngRoute', 'ui.bootstrap', 'ngTouch', 'ui.grid', 'ui.grid.pagination', 'ui.grid.edit', 'ui.grid.resizeColumns',
                                    'ui.grid.selection', 'ui.grid.moveColumns', 'ui.grid.saveState', 'ui.bootstrap', 'ngTagsInput', 'ngSanitize', 'ui.select']);

    angular.module("GlobalModule").run(rootModal);
    angular.module("GlobalModule").factory("modalService", ModalService);

})();

//Storing modal object in rootScope for calling in controllers
rootModal.$inject = ['$rootScope', '$modal'];
function rootModal($rootScope, $modal) {

    $rootScope.AppPath = $("#appPath").attr("href");
    $rootScope.ShowModal = function (funcOk, funcCancel, passData) {

        var modalInstance = $modal.open({
            templateUrl: passData.Template || 'messageModal.html',
            backdrop: 'static',
            keyboard: false,
            controller: passData.Controller || 'messageModalController',
            size: passData.Size,
            resolve: {
                passData: function () { return passData; }
            }
        });

        modalInstance.result.then(funcOk, funcCancel);
    };
}

// Controller xu ly cac thao tac cua message Modal
angular.module("GlobalModule").controller("messageModalController", MessageModalController);
MessageModalController.$inject = ['$scope', '$modalInstance', 'passData'];
function MessageModalController($scope, $modalInstance, passData) {

    //set data in modal scope
    $scope.data = passData;

    $scope.ok = function () {

        //Close and Pass return result
        $modalInstance.close('ok');

    };
    $scope.cancel = function () {

        $modalInstance.dismiss('cancel');

    };
}

//Wait-Dialog class to show Processing message in modal
function WaitDialog(modalContent) {

    modalContent = modalContent || "Processing...";
    var pleaseWaitDiv = $('<div class="modal fade" id="pleaseWaitDialog" data-backdrop="static" data-keyboard="false" role="dialog" aria-labelledby="basicModal" aria-hidden="true" tabindex="-1"><div class="modal-dialog modal-sm"><div class="modal-content"><div class="modal-header"><h4>' + modalContent + '</h4></div><div class="modal-body"><div class="progress progress-striped active"><div class="progress-bar" style="width: 90%;"/></div></div></div></div></div>');

    this.Show = function () {

        pleaseWaitDiv.modal();

    };
    this.Hide = function () {

        pleaseWaitDiv.modal('hide');

    };
}

//Service to call Modal
ModalService.$inject = ['$modal'];
function ModalService($modal) {

    var serviceObject = {};
    serviceObject.ShowModal = function (funcOk, funcCancel, passData) {

        var modalInstance = $modal.open(
            {
                templateUrl: passData.Template || 'gridModal.html',
                backdrop: 'static',
                keyboard: false,
                controller: passData.Controller || 'gridModalController',
                size: passData.Size || 'lg',
                resolve: {
                    data: function () {

                        return passData;

                    }
                }
            });

        modalInstance.result.then(funcOk, funcCancel);

    };

    return serviceObject;

}

//Service to show notification message
notifyService.$inject = ['$rootScope'];

//Service to show notification message
notifyService.$inject = ['$rootScope'];
function notifyService($rootScope) {

    $rootScope.queue = [];
    var serviceObject = {};

    serviceObject.add = function (item) {
        $rootScope.queue.push(item);
        setTimeout(function () {
            // remove the alert after 2000 ms
            $('.alerts .alert').eq(0).remove();
            $rootScope.queue.shift();
        }, 3000);
    },

    serviceObject.pop = function () {
        $rootScope.queue.pop();
    }

    return serviceObject;

}
