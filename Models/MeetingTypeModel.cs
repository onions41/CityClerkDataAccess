/*
  CREATE TABLE meeting_types (
    name VARCHAR(100) PRIMARY KEY,
  );
*/

namespace DataAccess.Models;

public class MeetingTypeModel
{
  public required string Name { get; set; }
}