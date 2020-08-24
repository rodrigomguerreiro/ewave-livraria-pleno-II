#!/bin/bash
set -e
if [ "$1" = '/opt/mssql/bin/sqlservr' ]; then

  if [ ! -f /tmp/app-initialized ]; then
    
    function initialize_database() {
      sleep 120s
      
      /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P todo@Dbpassword123 -d master -i /scriptFiles/Create.sql
      /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P todo@Dbpassword123 -d master -i /scriptFiles/Insert.sql
     
      touch /tmp/app-initialized
    }
    initialize_database &
  fi
fi
exec "$@"