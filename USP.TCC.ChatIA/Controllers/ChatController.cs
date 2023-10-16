using Microsoft.AspNetCore.Mvc;
using Azure.AI.OpenAI;
using Azure;

namespace USP.TCC.ChatIA.Controllers
{
    public class ChatController : Controller
    {
        public async Task<IActionResult> Index()
        {
            OpenAIClient client = new OpenAIClient(
                    new Uri("https://tccusp.openai.azure.com/"),
                    new AzureKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY")));

            Response<StreamingChatCompletions> response = await client.GetChatCompletionsStreamingAsync(
    deploymentOrModelName: "_teste01",
    new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatMessage(ChatRole.System, @"Tutor de gestão de projetos"),
            new ChatMessage(ChatRole.User, @"o que faço para gerenciar bem um projeto?"),
            new ChatMessage(ChatRole.Assistant, @"faça o curso na https://veduca.org/courses/gestao-de-projetos/"),
        },
        Temperature = (float)0.7,
        MaxTokens = 800,
        NucleusSamplingFactor = (float)0.95,
        FrequencyPenalty = 0,
        PresencePenalty = 0,
    });
            using StreamingChatCompletions streamingChatCompletions = response.Value;


            // ### If streaming is not selected
            Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
                "_teste01",
                new ChatCompletionsOptions()
                {
                    Messages =
                    {
            new ChatMessage(ChatRole.System, @"Tutor de gestão de projetos"),
            new ChatMessage(ChatRole.User, @"o que faço para gerenciar bem um projeto?"),
            new ChatMessage(ChatRole.Assistant, @"faça o curso na https://veduca.org/courses/gestao-de-projetos/"),
                    },
                    Temperature = (float)0.7,
                    MaxTokens = 800,
                    NucleusSamplingFactor = (float)0.95,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0,
                });

            ChatCompletions completions = responseWithoutStream.Value;
            return View();
        }
    }
}
