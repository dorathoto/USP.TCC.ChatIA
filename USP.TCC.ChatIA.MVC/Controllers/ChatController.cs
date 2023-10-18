using Azure;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using USP.TCC.ChatIA.MVC.Models;

namespace USP.TCC.ChatIA.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChatController : ControllerBase
    {
        public ChatController()
        {

        }
        [HttpGet]
        public async Task<IActionResult> Index(ChatPergunta model)
        {
            OpenAIClient client = new OpenAIClient(
                    new Uri("https://tccusp.openai.azure.com/"),
                    new AzureKeyCredential("Key"));

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
                            Temperature = model.Options.Temperature,
                            MaxTokens = model.Options.MaxTokens,
                            NucleusSamplingFactor = model.Options.NucleusSamplingFactor,
                            FrequencyPenalty = model.Options.FrequencyPenalty,
                            PresencePenalty = model.Options.FrequencyPenalty,
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
                    Temperature = model.Options.Temperature,
                    MaxTokens = model.Options.MaxTokens,
                    NucleusSamplingFactor = model.Options.NucleusSamplingFactor,
                    FrequencyPenalty = model.Options.FrequencyPenalty,
                    PresencePenalty = model.Options.FrequencyPenalty,
                });

            ChatCompletions completions = responseWithoutStream.Value;
            return Ok(completions.Choices[0].Message);
        }



        [HttpGet]
        public async Task<IActionResult> Pergunta(ChatPergunta model)
        {
            var retorno = new ChatResposta();
            retorno.Resposta = "Não entendi a pergunta";
            return Ok(retorno);
        }
    }
}
