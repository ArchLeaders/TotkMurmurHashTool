using CommunityToolkit.Mvvm.ComponentModel;
using TotkMurmurHashTool.Helpers;
using TotkMurmurHashTool.Views;

namespace TotkMurmurHashTool.ViewModels;

public partial class ShellViewModel : ObservableObject
{
    public ShellViewModel()
    {
    }

    public ShellViewModel(ShellView view)
    {
        _view = view;
    }

    private readonly ShellView? _view = null;

    [ObservableProperty]
    private string? _actorNames;

    [ObservableProperty]
    private string? _constants = "IsGetAnyway IsGet";

    partial void OnActorNamesChanged(string? value)
    {
        EvaluateResults();
    }

    partial void OnConstantsChanged(string? value)
    {
        EvaluateResults();
    }

    private void EvaluateResults()
    {
        if (ActorNames is null || Constants is null || _view is null) {
            return;
        }

        string[] actorNames = ActorNames.Trim().Split(' ');
        string[] constants = Constants.Trim().Split(' ');
        _view.ResultEditor.Text = YamlResultHelper.CreateGdlResult(actorNames, constants);
    }
}
