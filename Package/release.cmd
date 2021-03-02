"..\..\KingdomDev\oqtane.package\nuget.exe" pack TKA.Posts.nuspec 
XCOPY "*.nupkg" "..\..\KingdomDev\Oqtane.Server\wwwroot\Modules\" /Y
