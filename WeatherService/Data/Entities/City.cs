namespace WeatherService.Data.Entities;

public class City
{    
    public int Id { get; set; }

    //[Required] quando quero que o campo tenha o preenchimento obrigatório
    public string Name { get; set; }
    public double Temperature { get; set; }
    public DateTime LastUpdated { get; set; }


    // por convenção, permite criar a FK para o Country usando o nome da entidade seguido da prop
    // que representa a PK
    public int CountryId { get; set; }
    public Country Country { get; set; }
}
