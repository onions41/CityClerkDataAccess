/*
  CREATE TABLE records (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    meeting_id MEDIUMINT UNSIGNED NOT NULL,
    record_type_name VARCHAR(100) NOT NULL,

    url VARCHAR(2048),
    raw_data MEDIUMBLOB,
    extracted_text MEDIUMTEXT,

    CONSTRAINT fk_meeting FOREIGN KEY (meeting_id) REFERENCES meetings(id),
    CONSTRAINT fk_record_type FOREIGN KEY (record_type_name) REFERENCES record_types(name) ON UPDATE CASCADE,
    INDEX idx_meeting (meeting_id)
    INDEX idx_record_type (record_type_name)
  );
*/

namespace DataAccess.Models;

public class RecordModel
{
  public required uint Id { get; set; }
  public required uint MeetingId { get; set; }
  public required string RecordTypeName { get; set; }
  public string? Url { get; set; }
  public byte[]? RawData { get; set; }
  public string? ExtractedText { get; set; }

}