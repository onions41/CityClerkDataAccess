using Dapper.FluentMap;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Mapping;

namespace DataAccess.Data;

public class VideoData : IVideoData {
  private readonly IPostgresAccess _db;

  public VideoData(IPostgresAccess db) {
    // DI
    _db = db;
    // Maps model property names to database column names
    FluentMapper.Initialize(config => {
      config.AddConvention<PascalToSnakeConvention>()
        .ForEntity<MeetingModel>();
    });
  }

  public async Task<uint> InsertVideo(VideoModel video) {
    var statement = "INSERT INTO videos (url) VALUES (@Url) RETURNING videos.id";

    return await _db.InsertAndReturnId(
      statement,
      new { Url = video.Url },
      "CityClerkDb"
    );
  }
}
