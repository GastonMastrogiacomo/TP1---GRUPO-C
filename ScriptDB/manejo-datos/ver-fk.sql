SELECT
    fk.name AS ForeignKeyName,
    OBJECT_NAME(fk.parent_object_id) AS ParentTableName,
    COL_NAME(fkc.parent_object_id, fkc.parent_column_id) AS ParentColumnName,
    OBJECT_NAME(fk.referenced_object_id) AS ReferencedTableName,
    COL_NAME(fkc.referenced_object_id, fkc.referenced_column_id) AS ReferencedColumnName
FROM
    sys.foreign_keys AS fk
INNER JOIN
    sys.foreign_key_columns AS fkc ON fk.object_id = fkc.constraint_object_id
ORDER BY
    ParentTableName, ForeignKeyName;