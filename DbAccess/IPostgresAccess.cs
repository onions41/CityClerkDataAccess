namespace DataAccess.DbAccess;

public interface IPostgresAccess
{
   Task<IEnumerable<T>> LoadData<T, U>(string statement, U parameters, string connectionId = "Default");
   Task SaveData<T>(string statement, T parameters, string connectionId = "Default");

   Task<int?> InsertOne<T>(
      string statement,
      T parameters,
      string connectionId = "Default"
   );

   Task<T?> QueryOne<T, TParam>(
      string statement,
      TParam parameters,
      string connectionId = "Default"
   );
}