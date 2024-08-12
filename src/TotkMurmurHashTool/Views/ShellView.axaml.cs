using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaEdit.TextMate;
using FluentAvalonia.UI.Windowing;
using TextMateSharp.Grammars;
using TotkMurmurHashTool.ViewModels;

namespace TotkMurmurHashTool.Views;

public partial class ShellView : AppWindow
{
    private readonly RegistryOptions _registryOptions = new(ThemeName.DarkPlus);

    public ShellView()
    {
        InitializeComponent();
        DataContext = new ShellViewModel(this);

        Bitmap bitmap = new(AssetLoader.Open(new Uri("avares://TotkMurmurHashTool/Assets/icon.ico")));
        Icon = bitmap.CreateScaledBitmap(new(48, 48), BitmapInterpolationMode.HighQuality);

        TextMate.Installation installation = ResultEditor.InstallTextMate(_registryOptions);
        installation.SetGrammar(
            scopeName: "source.yaml"
        );
    }
}