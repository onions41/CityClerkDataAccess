using DataAccess.Models;

namespace DataAccess.Data;

public interface IDocumentData
{
   Task<int> InsertDocument(DocumentModel document, int meetingId, string meetingsDocumentsType);
}