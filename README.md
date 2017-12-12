# lost-pets-dashboard
UWP  dashboard application to help people find lost pets


## NuGet Libraries

* Newtonsoft.Json - for serializing C# object to make http requests.

Issue installing on VS2015; Project V.5.1.0; 

Solution: https://github.com/NuGet/Home/issues/4884

**datoroal** commented on Oct 4

Remove all aot 

**project.json**
```JSON
"runtimes": {
"win10-arm": {},
"win10-x86": {},
"win10-x64": {}
}
```