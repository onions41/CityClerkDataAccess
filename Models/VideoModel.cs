/*
  CREATE TABLE videos (
    id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,

    url VARCHAR(300) NOT NULL UNIQUE
  );
*/

public class VideoModel {
  public uint? Id { get; set; }
  public required string Url { get; set; }
}