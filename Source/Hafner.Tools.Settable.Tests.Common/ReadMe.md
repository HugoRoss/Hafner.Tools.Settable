# Hafner.Tools.Settable.Tests

As I experienced constant compilation errors because referenced DLLs were locked by multiple instances of Visual Studio's test runner ('testrunner.exe'), I split the test project into single test projects per target framework, using a common test logic defined here in Hafner.Tools.Settable.Tests.Common.

Known issues:
 - As .NET frameworks prior to version 4.5 needs other testing libraries (the ones of 'MSTest V1' instead of 'MSTest V2') I haven't added support for those yet.
 - Dapper extensions do not have unit tests yet