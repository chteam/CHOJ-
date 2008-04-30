@ECHO OFF

REM Step 1 - Generate the reflection information
"D:\Program Files\Sandcastle\ProductionTools\MRefBuilder" /config:MRefBuilder.config /out:reflection.org   *.dll *.exe
