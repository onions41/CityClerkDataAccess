using DataAccess.Models;

namespace DataAccess.Data;

public interface IMeetingData
{
  Task<MeetingModel?> GetMeeting(int id);
  Task<IEnumerable<MeetingModel>> GetMeetings();
}