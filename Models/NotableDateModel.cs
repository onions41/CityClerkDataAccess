/*
  CREATE TABLE notable_dates (
    municipality_name VARCHAR(100) NOT NULL,
    notable_date_type_name VARCHAR(100) NOT NULL,

    date DATE NOT NULL,

    CONSTRAINT pk_notable_date PRIMARY KEY (municipality_name, notable_date_type_name),
    CONSTRAINT fk_municipality_notable_date FOREIGN KEY (municipality_name) REFERENCES municipalities(name) ON UPDATE CASCADE,
    CONSTRAINT fk_notable_date_type FOREIGN KEY (notable_date_type_name) REFERENCES notable_date_types(name) ON UPDATE CASCADE,
    INDEX idx_municipality_notable_date (municipality_name),
    INDEX idx_notable_date_type (notable_date_type_name)
  );
*/

namespace DataAccess.Models;

public class NotableDateModel
{
  public required string MunicipalityName { get; set; }
  public required string NotableDateTypeName { get; set; }
  public required DateTime Date { get; set; }
}