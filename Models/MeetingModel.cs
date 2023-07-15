/*
  CREATE TABLE meetings (
    id MEDIUMINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    municipality_name VARCHAR(100) NOT NULL,
    meeting_type_name VARCHAR(100) NOT NULL,

    date DATE NOT NULL,
    url VARCHAR(2048),

    CONSTRAINT fk_municipality FOREIGN KEY (municipality_name) REFERENCES municipalities(name) ON UPDATE CASCADE,
    CONSTRAINT fk_meeting_type FOREIGN KEY (meeting_type_name) REFERENCES meeting_types(name) ON UPDATE CASCADE,
    INDEX idx_municipality (municipality_name),
    INDEX idx_meeting_type (meeting_type_name)
  );
*/

namespace DataAccess.Models;

public class MeetingModel
{
  public required uint Id { get; set; }
  public required string MunicipalityName { get; set; }
  public required string MeetingTypeName { get; set; }
  public required DateTime Date { get; set; }
  public string ?Url { get; set; }
}
