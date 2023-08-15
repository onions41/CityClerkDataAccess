namespace DataAccess.Models;

public class DocumentModel
{
   public int? Id { get; set; }
   public string? Url { get; set; }
   public required byte[] Fingerprint { get; set; }
   public string? TextContent { get; set; }
   public byte[]? RawContent { get; set; }
   public string? Format { get; set; }
   public string? Headline { get; set; }
}

/*
   CREATE TABLE documents (
      id SERIAL PRIMARY KEY,
      url VARCHAR(2048),
      fingerprint BYTEA NOT NULL UNIQUE,
      headline VARCHAR(300),
      text_content TEXT,
      raw_content BYTEA,
      format VARCHAR(100)
   );
   
   CREATE TABLE meetings_documents (
      meeting_id INTEGER,
      document_id INTEGER,

      type VARCHAR(100),
     
      CONSTRAINT pk_meetings_documents PRIMARY KEY (meeting_id, document_id),
      CONSTRAINT fk_documents_meetings FOREIGN KEY (meeting_id)
         REFERENCES meetings(id),
      CONSTRAINT fk_meetings_documents FOREIGN KEY (document_id)
         REFERENCES documents(id),
   );
*/