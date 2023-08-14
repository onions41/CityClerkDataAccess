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
  public int? Id { get; set; }
  public string? Url { get; set; }
  public required byte[] Fingerprint { get; set; }
  public string? TextContent { get; set; }
  public byte[]? RawContent { get; set; }
  public string? Format { get; set; }
  public string? Headline { get; set; }
}