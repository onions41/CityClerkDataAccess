using Dapper.FluentMap;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Mapping;

namespace DataAccess.Data;

public class MeetingData : IMeetingData
{
  private readonly ISqlDataAccess _db;

  public MeetingData(ISqlDataAccess db)
  {
    // DI
    _db = db;
    // Maps model property names to database column names
    FluentMapper.Initialize(config =>
    {
      config.AddConvention<PascalToSnakeConvention>()
        .ForEntity<MeetingModel>();
    });
  }

  public Task<IEnumerable<MeetingModel>> GetMeetings()
  {
    var statement = "SELECT * FROM meetings";

    return _db.LoadData<MeetingModel, dynamic>(statement, new { }, "CityScrapeDb");
  }

  public async Task<MeetingModel?> GetMeeting(int id)
  {
    var statement = "SELECT * FROM meetings WHERE id = @Id";

    var results = await _db.LoadData<MeetingModel, dynamic>(statement, new { Id = id }, "CityScrapeDb");
    return results.FirstOrDefault();
  }
}
