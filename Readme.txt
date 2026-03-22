# Cybersecurity Awareness Chatbot — Part 1
 
## PROG6221POE — Part 1: Basic Chatbot Interaction with Voice Greeting & Image
 
---
 
## Project Structure
 
```
CybersecurityChatbot/
├── Program.cs                  ← Main application (all logic)
├── CybersecurityChatbot.csproj ← Project configuration
└── README.md                   ← This file
```
 
---
 
## Features Implemented
 
| # | Requirement | Implementation |
|---|-------------|----------------|
| 1 | **Voice Greeting** | Text-to-Speech using `System.Speech.SpeechSynthesizer` — plays on launch |
| 2 | **ASCII Art Logo** | Multi-line ASCII art "CYBER SECURE" logo displayed as title header |
| 3 | **Text Greeting & User Interaction** | Asks for user's name, personalises all subsequent responses |
| 4 | **Basic Response System** | Handles: passwords, phishing, browsing, links, malware, scams, and general questions |
| 5 | **Input Validation** | Detects empty input, falls back to default response for unrecognised queries |
| 6 | **Enhanced Console UI** | Coloured text, decorative borders, section dividers, typing effect simulation |
 
---
 
## How to Run
 
### Prerequisites
- Windows OS (required for `System.Speech`)
- .NET 6 SDK or later → [Download here](https://dotnet.microsoft.com/download)
- Visual Studio 2022 **OR** VS Code with C# extension
 
### Option A — Visual Studio
1. Open `CybersecurityChatbot.csproj` in Visual Studio
2. Press **F5** or click **Run**
 
### Option B — Command Line (dotnet CLI)
```bash
cd CybersecurityChatbot
dotnet restore
dotnet run
```
 
---
 
## Sample Interaction
 
```
  [CyberBot starts, voice greeting plays]
 
  >> Please enter your name: Thabo
 
  Hello, Thabo! Great to have you here.
 
  [Thabo] >> How are you?
  [CyberBot] >> I'm doing great, Thabo! Ready to help you stay cyber-safe today.
 
  [Thabo] >> Tell me about phishing
  [CyberBot] >> Phishing is a serious threat, Thabo! Here's what to watch for:
      • Emails asking urgently for personal info...
 
  [Thabo] >> exit
  [CyberBot] >> Goodbye, Thabo! Stay safe online. 🔒
```
 
---
 
## Topics the Bot Responds To
- `password` — Password safety tips
- `phishing` — How to identify phishing attacks
- `browsing` / `internet` — Safe browsing practices
- `link` / `url` / `suspicious` — Spotting suspicious links
- `malware` / `virus` — Malware protection
- `scam` / `social engineering` — Social engineering awareness
- `how are you` — Friendly response
- `purpose` / `what do you do` — Bot purpose explanation
- `help` / `what can I ask` — Lists available topics
- `exit` / `quit` / `bye` — Exits the application
 
---
 
## Notes
- **Text-to-Speech** uses the built-in Windows SAPI engine via `System.Speech` — no additional software needed.
- The voice greeting plays **once on startup** before the ASCII art is shown.
- All responses are **personalised** using the user's entered name.
- The **typing effect** simulates a conversational feel by printing characters with a slight delay.
 