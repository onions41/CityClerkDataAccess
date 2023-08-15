using Dapper.FluentMap;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Mapping;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DataAccess.Data;

public class DocumentData : IDocumentData
{
   private readonly IPostgresAccess _db;
   private readonly ILogger<DocumentData> _logger;

   public DocumentData(IPostgresAccess db, ILogger<DocumentData> logger) {
      // DI
      _db = db;
      _logger = logger;
      // Maps model property names to database column names
      FluentMapper.Initialize(config => {
         config.AddConvention<PascalToSnakeConvention>()
            .ForEntity<DocumentModel>();
      });
   }

   // Inserts into one to documents table and one to meetings_documents table. Skips if row or rows exists.
   public async Task<int> InsertDocument(DocumentModel document, int meetingId, string meetingsDocumentsType) {
      const string insertDocStmt = """
                                     INSERT INTO documents (url, fingerprint, text_content, raw_content, format, headline)
                                     VALUES (@Url, @Fingerprint, @TextContent, @RawContent, @Format, @Headline)
                                     RETURNING id;
                                   """;

      int documentId;
      try {
         documentId = await _db.InsertOne(
            insertDocStmt,
            document,
            "CityClerkDb"
         ) ?? throw new NullReferenceException("Impossible. No ID returned when inserting document");
      } catch (PostgresException e) {
         // unique_violation exception 23505
         // www.postgresql.org/docs/current/errcodes-appendix.html
         if (e.SqlState != "23505") throw;
         
         _logger.LogInformation("Duplicate document row.");

         // Document with same fingerprint exists, query for the existing document
         const string findDocStmt = """
                                    SELECT * FROM documents WHERE fingerprint = @Fingerprint;
                                    """;

         var findDocParam = new {
            Fingerprint = document.Fingerprint
         };


         var existingDocument = await _db.QueryOne<DocumentModel, dynamic>(findDocStmt, findDocParam, "CityClerkDb")
                                ?? throw new NullReferenceException("Could not find document with that fingerprint");

         documentId = (int)existingDocument.Id!;
      }

      // Insert row in the join table
      const string insertJoinStmt = """
                                    INSERT INTO meetings_documents (meeting_id, document_id, type)
                                    VALUES (@MeetingId, @DocumentId, @Type);
                                    """;

      var insertJoinParams = new {
         MeetingId = meetingId,
         DocumentId = documentId,
         Type = meetingsDocumentsType
      };

      try {
         await _db.InsertOne(insertJoinStmt, insertJoinParams, "CityClerkDb");
      } catch (PostgresException e) {
         // unique_violation exception 23505
         // www.postgresql.org/docs/current/errcodes-appendix.html
         if (e.SqlState != "23505") throw;
         
         _logger.LogInformation("Duplicate meetings_documents join table row.");
      }

      return documentId;
   }
}