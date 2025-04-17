# Prueba técnica para Evoltis
Este repositorio contiene una api para manejar un CRUD de clientes básico, utilizando entity framework.

La api estará se levantará en: `http://localhost:5178`.

Además, es necesario crear un archivo en la ruta `/TechnicalTests.Api/.env`, con las siguientes variables de entorno:
```
    DB_HOST=localhost
    DB_PORT=3306
    DB_NAME=technical_tests_db
    DB_SA_USER=root
    DB_SA_PASSWORD=S3cr3t_123
```

Esto permitirá conectarse a la db de mysql.
Al levantar la api, se aplicarán automáticamente las migraciones necesarias, para generar la DB, con la tabla de customers.