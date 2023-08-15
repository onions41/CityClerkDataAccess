using Dapper.FluentMap;
using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Mapping;

namespace DataAccess.Data;

public class VideoData : IVideoData
{
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

   public async Task<int> InsertVideo(VideoModel video) {
      var statement = "INSERT INTO videos (url) VALUES (@Url) RETURNING videos.id";

      var videoId = await _db.InsertOne(
         statement,
         new { Url = video.Url },
         "CityClerkDb"
      );

      return videoId ?? throw new Exception("Impossible. Inserting the video did not return a videoId");
   }
}