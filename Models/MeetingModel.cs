/*
  CREATE TABLE meetings (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    municipality_name VARCHAR(100) NOT NULL,

    type VARCHAR(100) NOT NULL,
    date DATE NOT NULL,
    url VARCHAR(2048),

    CONSTRAINT fk_meetings_municipalities FOREIGN KEY (municipality_name)
      REFERENCES municipalities(name) ON UPDATE CASCADE,
  );
*/

namespace DataAccess.Models;

/*
  CREATE TABLE meetings (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    municipality_name VARCHAR(100) NOT NULL,

    type VARCHAR(100) NOT NULL,
    date DATE NOT NULL,
    url VARCHAR(2048),

    CONSTRAINT fk_meetings_municipalities FOREIGN KEY (municipality_name)
      REFERENCES municipalities(name) ON UPDATE CASCADE,
  );
*/

public class MeetingModel
{
  public int? Id { get; set; }
  public required string MunicipalityName { get; set; }
  public required string Type { get; set; }
  public required DateTime Date { get; set; }
  public string? Url { get; set; }
}
