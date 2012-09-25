copy src\geschikt\bin\Release\geschikt.dll nuget\lib\net40-client
pushd nuget
..\util\nuget.exe pack ProductivityExtensions.nuspec 
popd
