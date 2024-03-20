using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace ProductDetailManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : ControllerBase
    {
        [HttpPost]
        [Route("getAnswer")]
        public IActionResult getResult([FromBody] string prompt) {
            String APIKey = "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";
            string answer = string.Empty;
            var openai = new OpenAIAPI(APIKey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = prompt;
            completion.Model = OpenAI_API.Model.DavinciText;
            completion.MaxTokens = 4000;
            var result = openai.Completions.CreateCompletionAsync(completion);
            if (result != null)
            {
                foreach (var item in result.Result.Completions)
                {

                    answer = item.Text;


                }
                return Ok(answer);

            }
            else { 
              return BadRequest("NotFound");
            }
        

        }
    }
}
