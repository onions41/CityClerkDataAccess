/*
  CREATE TABLE notable_date_types (
    name VARCHAR(100) PRIMARY KEY,

    description VARCHAR(300)
  );
*/

namespace DataAccess.Models;

public class NotableDateTypeModel
{
  public required string Name { get; set; }
  public string? description { get; set; }
}