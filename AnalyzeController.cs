using Microsoft.AspNetCore.Mvc;
using SmartResumeAnalyzer.Services;

namespace SmartResumeAnalyzer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnalyzeController : ControllerBase
    {
        private readonly IResumeAnalyzer _resumeAnalyzer;

        public AnalyzeController(IResumeAnalyzer resumeAnalyzer)
        {
            _resumeAnalyzer = resumeAnalyzer;
        }

        [HttpPost("match")]
        public async Task<IActionResult> AnalyzeMatch([FromBody] ResumeInput input)
        {
            var result = await _resumeAnalyzer.AnalyzeResumeMatchAsync(input);
            return Ok(result);
        }
    }
}
