FROM postgres
EXPOSE 5432
COPY ./scripts/ /docker-entrypoint-initdb.d/
COPY ./admin/ /
RUN bash 03_script.sh
VOLUME [ "./volume/postgres:/var/lib/postgresql/data" ]