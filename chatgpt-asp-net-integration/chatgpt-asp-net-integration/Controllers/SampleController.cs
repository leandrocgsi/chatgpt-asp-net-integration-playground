using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace ChatGPT.ASP.NET.Integration.Controllers;

[Route("api/[controller]")]
public class SampleController : Controller
{
	private readonly OpenAIAPI _chatGpt;

	public SampleController(OpenAIAPI chatGpt)
	{
		_chatGpt = chatGpt;
	}

	[HttpGet]
	public async Task<IActionResult> GetSampleChatpGpt(string text)
	{
		var response = string.Empty;
		var completion = new CompletionRequest
		{
			Prompt = text,
			Model = Model.ChatGPTTurbo,
			MaxTokens = 200
		};

		var result = await _chatGpt.Completions.CreateCompletionAsync(completion);

		result.Completions.ForEach(resultText => response = resultText.Text);

		return Ok(response);
	}
}