/*
  CREATE TABLE record_types (
    name VARCHAR(100) PRIMARY KEY,
  );
*/

namespace DataAccess.Models;

public class RecordTypeModel
{
  public required string Name { get; set; }
}