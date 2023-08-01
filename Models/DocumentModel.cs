/*
  CREATE TABLE documents (
    id SERIAL PRIMARY KEY,

    url VARCHAR(2048),
    fingerprint CHAR(100) NOT NULL UNIQUE,
    content TEXT
  );
*/

namespace DataAccess.Models;

public class DocumentModel {
  public uint? Id { get; set; }
  public string? Url { get; set; }
  public required string Fingerprint { get; set; }
  public string? Content { get; set; }
}