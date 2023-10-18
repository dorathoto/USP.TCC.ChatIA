using System.ComponentModel.DataAnnotations;

namespace USP.TCC.ChatIA.MVC.Models;

public class ChatOptions
{
    [Range(0.1, 1.0, ErrorMessage = "O valor deve estar entre 0.1 e 1.0")]
    public float? Temperature { get; set; } = 0.7f;
    public int? MaxTokens { get; set; } = 800;
    public float? NucleusSamplingFactor { get; set; } = 0.95f;
    public float? PresencePenalty { get; set; } = 0;
    public float? FrequencyPenalty { get; set; } = 0;
}
