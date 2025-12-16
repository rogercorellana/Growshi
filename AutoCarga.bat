@ECHO OFF
ECHO Iniciando carga diaria de Growshi DW...
sqlcmd -S .\SQLEXPRESS -E -i "C:\Growshi_Auto\EjecutarETL.sql"
ECHO Carga finalizada.
