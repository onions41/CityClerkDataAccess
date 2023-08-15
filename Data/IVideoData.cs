using DataAccess.Models;

namespace DataAccess.Data;

public interface IVideoData {
  Task<int> InsertVideo(VideoModel video);
}
