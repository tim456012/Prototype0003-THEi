set arg1=%~1
set arg2=%~2
set arg3=%~3

"Inno Setup 6\ISCC.exe" "/DBuildSource=%arg1%" "/DBuildTarget=%arg2%" "/DMyAppVersion=%arg3%" setup.iss