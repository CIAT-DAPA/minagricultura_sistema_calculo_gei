FROM postgres
EXPOSE 5432
COPY ./scripts/ /docker-entrypoint-initdb.d/
VOLUME [ "../volume/postgres:/var/lib/postgresql/data" ]