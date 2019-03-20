# ApparareManifestJson
A Content App for Umbraco 8 that generates a managable manifest.json file for all the root nodes.

*This package is in progress, and so is not yet fully functional!*

## Installation guide
1. Download the project and add the [plugin folder](https://github.com/koenvanras/ApparareManifestJson/tree/master/App_Plugins/ApparareManifestJson) to the App_Plugins of your Umbraco 8 website.
2. Open the .sln file with Visual Studio and build the project.
3. Add a reference from Apparare.ManifestJson.dll to your Umbraco Website.
4. Build your Umbraco website.
5. Add the following code to your web.config handlers:
```
<remove name="ManifestJsonHandler" />
<add name="ManifestJsonHandler" type="ManifestJsonPlugin.Handlers.HttpHandlers.ManifestJsonHandler" path="manifest.json" preCondition="integratedMode" verb="*" />
```


## Compatible Umbraco versions
- 8.0.0
- 8.0.1
