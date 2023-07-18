using DataAccess.Models;

namespace DataAccess.Data;

public interface IRecordData
{
  Task<RecordModel?> GetRecord(int id);
  Task<IEnumerable<RecordModel>> GetRecords(int meetingId);
}
