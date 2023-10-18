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
        private readonly IConfiguration Configuration;
        private readonly Settings _appSettings;
        public ChatController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Pergunta(ChatPergunta model)
        {
            var key = Configuration["Azure:Key"];

            OpenAIClient client = new OpenAIClient(
                    new Uri("https://tccusp.openai.azure.com/"),
                    new AzureKeyCredential(key));

  

            // ### If streaming is not selected
            Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
                "_teste01",
                new ChatCompletionsOptions()
                {
                    Messages =
                    {
        new ChatMessage(ChatRole.User, model.Pergunta)
                    },
                    Temperature = model.Options.Temperature,
                    MaxTokens = model.Options.MaxTokens,
                    NucleusSamplingFactor = model.Options.NucleusSamplingFactor,
                    FrequencyPenalty = model.Options.FrequencyPenalty,
                    PresencePenalty = model.Options.FrequencyPenalty,
                });

            ChatCompletions completions = responseWithoutStream.Value;

            var retorno = new ChatResposta();
            retorno.Resposta = completions.Choices[0].Message.Content;
            retorno.Acuracia = completions.Usage.TotalTokens / completions.Usage.CompletionTokens;
            return Ok(retorno);
        }




    }
}
