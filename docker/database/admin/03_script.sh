VARIABLESFILE=.env

if [ -f "$VARIABLESFILE" ]
then
source $VARIABLESFILE
echo Editanto el archivo 04_dbUserAdmin.sql
  cat > /docker-entrypoint-initdb.d/04_dbUserAdmin.sql <<EOF
INSERT INTO public.usuario (email, idrol, enabled) VALUES ('${USER_ADMIN}', 6, true);
EOF

echo "archivo creado"
cat /docker-entrypoint-initdb.d/04_dbUserAdmin.sql
else
    echo "Archivo de variables no encontrado."
fi

