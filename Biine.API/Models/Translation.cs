namespace Biine.API.Models;

public class Translation
{
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string TextSv { get; set; } = string.Empty;
    public string TextEn { get; set; } = string.Empty;
}
