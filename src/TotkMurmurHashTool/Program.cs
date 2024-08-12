using Avalonia;
using TotkMurmurHashTool.Helpers;

namespace TotkMurmurHashTool;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        if (args.Length > 0) {
            args.GetInputs(out string[] actorNames, out string[] constants);
            Console.WriteLine(YamlResultHelper.CreateGdlResult(actorNames, constants));
            return;
        }

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}
