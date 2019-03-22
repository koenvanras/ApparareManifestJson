# ApparareManifestJson
![version](https://img.shields.io/badge/version-1.0.0--alpha-blue.svg)
[![our-umbraco](https://img.shields.io/badge/our-umbraco-%23ef7d00.svg)](https://our.umbraco.com/packages/backoffice-extensions/apparare-manifest-json/)



A Content App for Umbraco 8 that generates a managable manifest.json file for all the root nodes.

*This package is in progress, and so is not yet fully functional!*

If you experience any issues, please let me know!

Feel free to make a pull request if you want to change/add something.

## TODO
- Create logic to create database table if it doesn't exist
- Change permissions to only show on nodes that have a hostname set up (for admin users)
- Add icons to the manifest data
- Create NuGet package
- Create logic to add web.config handler if it doesn't exist

## Installation guide
1. Download the project and add the [plugin folder](https://github.com/koenvanras/ApparareManifestJson/tree/master/App_Plugins/ApparareManifestJson) to the App_Plugins of your Umbraco 8 website.
2. Open the .sln file with Visual Studio and build the project.
3. Add a reference from Apparare.ManifestJson.dll to your Umbraco Website.
4. Build your Umbraco website.
5. Add the following code to your web.config handlers:
```
<remove name="ManifestJsonHandler" />
<add name="ManifestJsonHandler" type="ApparareManifestJson.Handlers.HttpHandlers.ManifestJsonHandler" path="manifest.json" preCondition="integratedMode" verb="*" />
```


## Compatible Umbraco versions
- 8.0.0
- 8.0.1


## License
[![GitHub](https://img.shields.io/github/license/koenvanras/ApparareManifestJson.svg)](https://github.com/koenvanras/ApparareManifestJson/blob/master/LICENSE)
