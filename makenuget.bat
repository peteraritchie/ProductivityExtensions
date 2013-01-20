copy src\geschikt\bin\Release\geschikt.dll nuget\lib\net40-client
copy src\geschikt.net45\bin\Release\geschikt.dll nuget\lib\net45
copy src\geschikt.wp7\Bin\Release\geschikt.wp7.dll nuget\lib\sl4-wp 
pushd nuget
..\util\nuget.exe pack ProductivityExtensions.nuspec 
popd
