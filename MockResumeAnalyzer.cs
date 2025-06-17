namespace SmartResumeAnalyzer.Services
{
    public class MockResumeAnalyzer : IResumeAnalyzer
    {
        public Task<ResumeAnalysisResult> AnalyzeResumeMatchAsync(ResumeInput input)
        {
            return Task.FromResult(new ResumeAnalysisResult
            {
                AnalysisText = $@"Mocked Response:
Match Score: 85%
Key Strengths: C#, SQL, REST APIs, Azure
Missing Skills: AWS, React Testing Library"
            });
        }
    }
}
