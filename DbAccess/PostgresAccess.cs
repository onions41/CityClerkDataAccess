using Npgsql;
using Dapper;
using Dapper.FluentMap;
using DataAccess.Mapping;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DbAccess;

public class PostgresAccess : IPostgresAccess
{
   private readonly IConfiguration _config;

   public PostgresAccess(IConfiguration config) {
      _config = config;
      FluentMapper.Initialize(config => {
         config.AddConvention<PascalToSnakeConvention>()
            .ForEntity<MeetingModel>();
      });
   }

   // This gotta be async, so it doesn't lokc up the UIdf
   // T is going to be one of the defined model type. Ie, the type this function returns
   public async Task<IEnumerable<T>> LoadData<T, U>(
      string statement,
      U parameters,
      string connectionId = "Default"
   ) // Name of the connection string, which I will have to initialize with user secrets
   {
      // Use the using so the connection closes properly even if something crashes
      // This needs to be done whenever connecting to a database
      using NpgsqlConnection connection = new(_config.GetConnectionString(connectionId));

      // This is going ot return IEnumerable<T>
      // Dapper extends the connection by providing these Query methods
      return await connection.QueryAsync<T>(statement, parameters);

      // When you come back https://youtu.be/dwMFg6uxQ0I?t=2985
   }

   public async Task SaveData<T>(
      string statement,
      T parameters,
      string connectionId = "Default"
   ) {
      using NpgsqlConnection connection = new(_config.GetConnectionString(connectionId));
      await connection.ExecuteAsync(statement, parameters);

      // https://youtu.be/dwMFg6uxQ0I?t=3233
   }

   // Inserts one row and returns ID if ID was auto-generated
   public async Task<int?> InsertOne<T>(
      string statement,
      T parameters,
      string connectionId = "CityClerkDb"
   ) {
      await using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));
      return await connection.QuerySingleOrDefaultAsync<int?>(statement, parameters);
   }
}