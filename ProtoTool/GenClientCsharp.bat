chcp 65001
@echo off

if "%1"=="" (
for %%f in (protocols\config\*.proto) do	call protoc.exe --proto_path=protocols\config --csharp_out=..\Assets\GamePlay\Scripts\Protobuf\Config %%f) else (
call protoc.exe --proto_path=protocols\config --csharp_out=..\Assets\GamePlay\Scripts\Protobuf\Config %1
)

if "%1"=="" (
for %%f in (protocols\msg\*.proto) do	call protoc.exe --proto_path=protocols\msg --csharp_out=..\Assets\GamePlay\Scripts\Protobuf\Msg %%f) else (
call protoc.exe --proto_path=protocols\msg --csharp_out=..\Assets\GamePlay\Scripts\Protobuf\Msg %1
)

@REM if "%1"=="" (
@REM for %%f in (protocols\editor\*.proto) do	call protoc.exe --proto_path=protocols\config --proto_path=protocols\editor --csharp_out=..\Assets\Tools\Editor\Protobuf %%f) else (
@REM call protoc.exe --proto_path=protocols\editor --csharp_out=..\Assets\Tools\Editor\Protobuf %1
@REM )

@echo "finish build......"
pause
