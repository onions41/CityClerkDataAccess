/*
  CREATE TABLE documents (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,

    url VARCHAR(2048),
    fingerprint CHAR(100) NOT NULL UNIQUE,
    content MEDIUMTEXT NOT NULL
  );
*/

namespace DataAccess.Models;

public class DocumentModel {
  public uint? Id { get; set; }
  public string? Url { get; set; }
  public required string Fingerprint { get; set; }
  public required string Content { get; set; }
}