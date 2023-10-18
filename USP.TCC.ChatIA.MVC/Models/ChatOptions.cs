namespace USP.TCC.ChatIA.MVC.Models;

public class ChatOptions
{
    public float? Temperature { get; set; } = 0.7f;
    public int? MaxTokens { get; set; } = 800;
    public float? NucleusSamplingFactor { get; set; } = 0.95f;
    public float? PresencePenalty { get; set; } = 0;
    public float? FrequencyPenalty { get; set; } = 0;
}
