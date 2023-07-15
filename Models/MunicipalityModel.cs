/*
  CREATE TABLE municipalities (
    name VARCHAR(100) PRIMARY KEY
  );
*/

namespace DataAccess.Models;

public class MunicipalityModel
{
  public required string Name { get; set; }
}