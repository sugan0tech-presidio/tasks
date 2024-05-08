
GRANT SELECT ON employee TO guest;

SELECT *
FROM sys.database_principals
WHERE type_desc = 'SQL_USER';

REVOKE SELECT ON employee FROM guest;


SELECT *
FROM sys.database_principals
WHERE type_desc = 'SQL_USER';

