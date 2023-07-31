// // We are not going to talk to the SQL database directly from the MVC
// // Instead, the MVC will talk to these things in the Data folder
// // https://youtu.be/dwMFg6uxQ0I?t=3326
// // These will be injected into the controllers

// using DataAccess.DbAccess;
// using DataAccess.Models;

// namespace DataAccess.Data;

// public class UserData
// {
//   private readonly ISqlDataAccess _db;

//   public UserData(ISqlDataAccess db)
//   {
//     _db = db;
//   }

//   public Task<IEnumerable<UserModel>> GetUsers()
//   {
//     return _db.LoadData<UserModel, dynamic>("the stored procedure", new { });
//   }

//   public async Task<UserModel?> GetUser(uint id)
//   {
//     var results = await _db.LoadData<UserModel, dynamic>("the stroed prodcure", new { Id = id });
//     // First mean the first item in the set the LoadData (through dapper will be returning), or the default, which is Null.
//     return results.FirstOrDefault();
//   }

//   public Task InsertUser(UserModel user) =>
//     _db.SaveData("the storedfsdhp", new { user.FirstName, user.LastName });

//     // Update https://youtu.be/dwMFg6uxQ0I?t=4054
// }
