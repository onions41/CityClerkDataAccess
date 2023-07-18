using Dapper.FluentMap;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Mapping;

namespace DataAccess.Data;

public class RecordData : IRecordData
{
  private readonly ISqlDataAccess _db;

  public RecordData(ISqlDataAccess db)
  {
    // DI
    _db = db;
    // Maps model property names to database column names
    FluentMapper.Initialize(config =>
    {
      config.AddConvention<PascalToSnakeConvention>()
        .ForEntity<RecordModel>();
    });
  }

  public Task<IEnumerable<RecordModel>> GetRecords(int meetingId)
  {
    var statement = "SELECT * FROM records WHERE meeting_id = @MeetingId";

    return _db.LoadData<RecordModel, dynamic>(statement, new { MeetingId = meetingId }, "CityScrapeDb");
  }

  public async Task<RecordModel?> GetRecord(int id)
  {
    var statement = "SELECT * FROM records WHERE id = @Id";

    var results = await _db.LoadData<RecordModel, dynamic>(statement, new { Id = id }, "CityScrapeDb");
    return results.FirstOrDefault();
  }
}
