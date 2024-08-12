using Avalonia.Media.Imaging;
using Avalonia.Platform;
using FluentAvalonia.UI.Windowing;

namespace TotkMurmurHashTool.Views;

public partial class ShellView : AppWindow
{
    public ShellView()
    {
        InitializeComponent();

        Bitmap bitmap = new(AssetLoader.Open(new Uri("avares://TotkMurmurHashTool/Assets/icon.ico")));
        Icon = bitmap.CreateScaledBitmap(new(48, 48), BitmapInterpolationMode.HighQuality);
    }
}