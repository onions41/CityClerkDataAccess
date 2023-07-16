namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
  Task<IEnumerable<T>> LoadData<T, U>(string statement, U parameters, string connectionId = "Default");
  Task SaveData<T>(string statement, T parameters, string connectionId = "Default");
}