(function () {
    'use strict';

    function ManifestJsonPlugin($scope, editorState, $http, userService, contentResource, $window, notificationsService) {
        var vm = this;

        vm.debug = false;

        var domains = editorState.current.urls;
        var umbracoSettings = $window.Umbraco.Sys.ServerVariables.umbracoSettings;
        var apiUrl = umbracoSettings.umbracoPath + "/backoffice/ManifestJsonPlugin/BackofficeApi/";

        $(".spectrum-color").spectrum({
            preferredFormat: "hex",
            showInput: true,
            change: function (color) {
                $(this).parent().find(".spectrum-display").text(color.toHexString());
            }
        });

        vm.propertyHostnames = [];
        
        domains.forEach(element => {
            if (element.text !== "/")
                vm.propertyHostnames.push(element.text + "manifest.json");
        });

        $scope.saveManifestJsonDbData = function () {
            notificationsService.warning("Warning", "Saving data to the database...");
            $http.post(
                apiUrl + "CreateDbData",
                JSON.stringify({
                    NodeId: editorState.current.id,
                    Name: $(".manifest-json-plugin__name").val(),
                    ShortName: $(".manifest-json-plugin__short-name").val(),
                    Description: $(".manifest-json-plugin__description").val(),
                    ThemeColor: $(".manifest-json-plugin__theme-color").parent().find(".spectrum-display").text(),
                    BackgroundColor: $(".manifest-json-plugin__background-color").parent().find(".spectrum-display").text()
                })
            ).then(function (response) {
                vm.currentManifestResponse = response.data.result;
                
                if (response.data.status === "data_created") {
                    notificationsService.success("Created", "The data was successfully created in the database.");
                } else if (response.data.status === "data_updated") {
                    notificationsService.success("Updated", "The data was successfully saved to the database.");
                } else if (response.data.status === "data_unchanged") {
                    notificationsService.success("Unchanged", "The input data was unchanged, no database changes were made.");
                }

                if (response.status !== 200) {
                    notificationsService.error("Error!", response);
                }
            });
        };

        $http.get(
            apiUrl + "GetDbData?nodeId=" + editorState.current.id
        ).then(function (response) {
            vm.currentManifestResponse = response.data;
            setSpectrumColor($(".manifest-json-plugin__background-color"), response.data.BackgroundColor);
            setSpectrumColor($(".manifest-json-plugin__theme-color"), response.data.ThemeColor);
            });
    }

    function setSpectrumColor(object, color) {
        if (color !== "" && object !== null) {
            object.spectrum("set", color);
            object.parent().find(".spectrum-display").text(color);
        }
    }
    angular.module("umbraco").controller("Apparare.ManifestJsonPlugin", ManifestJsonPlugin);
})();

