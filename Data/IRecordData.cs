using DataAccess.Models;

namespace DataAccess.Data;

public interface IRecordData
{
  Task<DocumentModel?> GetRecord(int id);
  Task<IEnumerable<DocumentModel>> GetRecords(int meetingId);
}
