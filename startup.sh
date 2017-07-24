#!/usr/bin/env bash

echo "Starting up!"
exec env PORT=$PORT /usr/bin/supervisord -c /app/supervisord.conf
echo "Finished!"