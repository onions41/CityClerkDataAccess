using DataAccess.Models;

namespace DataAccess.Data;

public interface IMeetingData
{
  Task<IEnumerable<MeetingModel>> GetMeetings();
}