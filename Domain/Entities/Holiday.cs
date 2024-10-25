namespace Domain.Entities;

public class Holiday
{
    public string? name { get; set; }
    public string? name_local { get; set; }
    public string? language { get; set; }
    public string? description { get; set; }
    public string? country { get; set; }
    public string? location { get; set; }
    public string? type { get; set; }
    public string? date { get; set; }
    public string? date_year { get; set; }
    public string? date_month { get; set; }
    public string? date_day { get; set; }
    public string? week_day { get; set; }   
    public DateTime? ApiCall { get; set; }
}
