using Azure;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using USP.TCC.ChatIA.MVC.Models;

namespace USP.TCC.ChatIA.MVC.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ChatController : ControllerBase
{
    private readonly IConfiguration Configuration;
    private readonly Settings _appSettings;
    private SessionQuestions _sessionQuestions;

    public ChatController(IConfiguration configuration)
    {
        Configuration = configuration;
        _sessionQuestions = new SessionQuestions();
    }


    [HttpPost]
    public async Task<IActionResult> Pergunta(ChatPergunta model)
    {
        var key = Configuration["Azure:Key"];
        var endpoint = Configuration["Azure:EndPoint"];

        var client = new OpenAIClient(
                new Uri(endpoint),
                new AzureKeyCredential(key));


        var serializedObject2 = HttpContext.Session.GetString("TCChave");
        if (!string.IsNullOrEmpty(serializedObject2))
        {
            _sessionQuestions = JsonConvert.DeserializeObject<SessionQuestions>(serializedObject2); // Desserializa a string JSON de volta para o objeto
                                                                                                       // Agora você pode usar o objetoRecuperado normalmente
        }




        var messages = new List<ChatMessage>();

        foreach (var item in _sessionQuestions.Questoes)
        {
            messages.Add(new ChatMessage(ChatRole.System, item));
        }

        messages.Add(new ChatMessage(ChatRole.User, model.Pergunta));

        //add question to session
        _sessionQuestions.Questoes.Add(model.Pergunta);



        var options = new ChatCompletionsOptions(messages)
        {
            Temperature = model.Options.Temperature,
            MaxTokens = model.Options.MaxTokens,
            NucleusSamplingFactor = model.Options.NucleusSamplingFactor,
            FrequencyPenalty = model.Options.FrequencyPenalty,
            PresencePenalty = model.Options.FrequencyPenalty,
        };



        Response<ChatCompletions> responseWithoutStream = await client.GetChatCompletionsAsync(
            "_teste01",
            options);

        ChatCompletions completions = responseWithoutStream.Value;

        var resposta = completions.Choices[0].Message.Content;
        var retorno = new ChatResposta
        {
            Resposta = resposta.Replace("OpenAI", "Léo IA TCC Corporation").Replace("Sam Altman", "Bruce Lee"),
            TotalTokens = completions.Usage.TotalTokens
        };

        _sessionQuestions.Questoes.Add(retorno.Resposta);
        var serializedObject = JsonConvert.SerializeObject(_sessionQuestions);
        HttpContext.Session.SetString("TCChave", serializedObject);

        return Ok(retorno);
    }
}
