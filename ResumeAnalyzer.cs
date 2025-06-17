using OpenAI_API;

namespace SmartResumeAnalyzer.Services
{
    public class ResumeAnalyzer : IResumeAnalyzer
    {
        private readonly OpenAIAPI _openAiApi;

        public ResumeAnalyzer(OpenAIAPI openAiApi)
        {
            _openAiApi = openAiApi;
        }

        public async Task<ResumeAnalysisResult> AnalyzeResumeMatchAsync(ResumeInput input)
        {
            var prompt = $"""
            Compare the following resume to the job description.
            Return a match percentage, key strengths, and missing skills.

            Resume:
            {input.ResumeText}

            Job Description:
            {input.JobDescription}
            """;

            var completion = await _openAiApi.Completions.CreateCompletionAsync(prompt, temperature: 0.7, max_tokens: 300);
            return new ResumeAnalysisResult { AnalysisText = completion.ToString() };
        }
    }

    public interface IResumeAnalyzer
    {
        Task<ResumeAnalysisResult> AnalyzeResumeMatchAsync(ResumeInput input);
    }

    public class ResumeInput
    {
        public string ResumeText { get; set; }
        public string JobDescription { get; set; }
    }

    public class ResumeAnalysisResult
    {
        public string AnalysisText { get; set; }
    }
}
