/*
  CREATE TABLE videos (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,

    url VARCHAR(300) NOT NULL UNIQUE
  );
*/

namespace DataAccess.Models;

public class VideoModel {
  public int? Id { get; set; }
  public required string Url { get; set; }
}