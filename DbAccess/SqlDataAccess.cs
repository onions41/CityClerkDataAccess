using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;
using MySqlConnector;

namespace DataAccess.DbAccess;

// This will talk to SQL using Dapper
// We will create a generic interface for this so the code doesn't have to
// contain all the setup and teardown of talking to SQL

public class SqlDataAccess : ISqlDataAccess

// Extract the interface later to use it in dependency injection
{
  private readonly IConfiguration _config;

  public SqlDataAccess(IConfiguration config)
  {
    _config = config;
  }

  // This gotta be async, so it doesn't lokc up the UI
  // T is going to be one of the defined model type. Ie, the type this function returns
  public async Task<IEnumerable<T>> LoadData<T, U>(
    string statement,
    U parameters,
    string connectionId = "Default") // Name of the connection string, which I will have to initialize with user secrets
  {
    // Use the using so the connection closes properly even if something crashes
    // This needs to be done whenever connecting to a database
    using MySqlConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

    // This is going ot return IEnumerable<T>
    // Dapper extends the connection by providing these Query methods
    return await connection.QueryAsync<T>(statement, parameters);

    // When you come back https://youtu.be/dwMFg6uxQ0I?t=2985
  }

  public async Task SaveData<T>(
    string statement,
    T parameters,
    string connectionId = "Default")
  {
    using MySqlConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

    await connection.ExecuteAsync(statement, parameters);
    // https://youtu.be/dwMFg6uxQ0I?t=3233
  }
}

