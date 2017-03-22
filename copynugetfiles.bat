if not exist nuget\lib\net40-client md nuget\lib\net40-client
copy src\geschikt\bin\Release\geschikt.dll nuget\lib\net40-client
copy src\geschikt\bin\Release\geschikt.pdb nuget\lib\net40-client
if not exist nuget\lib\net45 md nuget\lib\net45
copy src\geschikt.net45\bin\Release\geschikt.dll nuget\lib\net45
copy src\geschikt.net45\bin\Release\geschikt.pdb nuget\lib\net45
nuget.exe pack nuget\ProductivityExtensions.nuspec -Symbols -version %APPVEYOR_BUILD_VERSION%