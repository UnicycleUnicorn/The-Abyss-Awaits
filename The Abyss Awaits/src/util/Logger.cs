using System.Diagnostics;

namespace The_Abyss_Awaits.util;

public static class Logger {
    private static readonly string Time = DateTime.Now.ToString("MM-dd__HH-mm");
    private static readonly string LogFile = $"../../Log/{Time}.html";

    static Logger() {
        // Setup to html log file by adding boilerplate html and css
        using var w = File.AppendText(LogFile);
        w.WriteLine(@"
            <!doctype html>
            <html lang=""en"">
            <head>
                <meta charset=""utf-8"">
                <title>" + Time + @" LOG</title>
                <style>
                    html, body {
                        background-color: black;
                    }
                    span {
                        display: block;
                    }
                    .error {
                        color: red;
                    }
                    .debug {
                        color: lightgreen;
                    }
                    .info {
                        color: white;
                    }
                    .warn {
                        color: yellow;
                    }
                </style>
            </head>
            <body>
            ");
    }

    public static void Warn(string text) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Log(text, "warn");
        Console.ResetColor();
    }

    public static void Info(string text) {
        Log(text, "info");
    }

    public static void Debug(string text) {
        Console.ForegroundColor = ConsoleColor.Green;
        Log(text, "debug");
        Console.ResetColor();
    }

    public static void Error(string text) {
        Console.ForegroundColor = ConsoleColor.Red;
        Log(text, "error");
        Console.ResetColor();
    }
    
    public static void ShowLog() {
        try {
            Process.Start(new ProcessStartInfo(Path.Combine(Environment.CurrentDirectory, LogFile))
                { UseShellExecute = true });
        } catch (Exception e) {
            Warn(e.ToString());
        }
    }
    
    private static void Log(string text, string clss) {
        text = $"{DateTime.Now} : {text}";
        Console.WriteLine(text);
        using (var w = File.AppendText(LogFile)) {
            w.WriteLine($"<span class=\"{clss}\">{text}</span>");
        }
    }
}