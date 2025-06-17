const root = document.getElementById("root");

const form = document.createElement("form");
form.innerHTML = `
  <h2>Smart Resume Analyzer</h2>
  <textarea id="resume" rows="6" cols="60" placeholder="Paste resume text here..."></textarea><br/>
  <textarea id="job" rows="6" cols="60" placeholder="Paste job description here..."></textarea><br/>
  <button type="submit">Analyze</button>
  <pre id="result" style="margin-top: 20px;"></pre>
`;

form.onsubmit = async (e) => {
  e.preventDefault();
  const resumeText = document.getElementById("resume").value;
  const jobDescription = document.getElementById("job").value;

  const response = await fetch("https://localhost:5001/api/analyze/match", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ resumeText, jobDescription })
  });

  const data = await response.json();
  document.getElementById("result").textContent = data.analysisText || JSON.stringify(data, null, 2);
};

root.appendChild(form);
