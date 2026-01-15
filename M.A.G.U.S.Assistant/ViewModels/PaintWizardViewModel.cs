using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class PaintWizardViewModel : BaseViewModel
{
    private IRelayCommand? selectToolCommand;
    private IRelayCommand? selectColorCommand;
    private IDrawableElement? currentElement;
    private PaintTool activeTool = PaintTool.Pencil;
    private Color selectedColor = GetDefaultColor();
    private string defaultText = "𝕸.𝕬.𝕲.𝖀.𝕾. - Ҝ.Ա.Ψ.Ᵽ.⅃.";
    private bool autoFill;
    private bool isCircleRectMode;
    private Color backgroundColor = Colors.White;

    public PaintWizardViewModel()
    {
        DrawingLogic = new PaintCanvasDrawable { ViewModel = this };
    }

    public IDrawableElement? CurrentElement
    {
        get => currentElement;
        set => SetProperty(ref currentElement, value);
    }

    public PaintCanvasDrawable DrawingLogic { get; }

    public ObservableCollection<IDrawableElement> Elements { get; } = [];

    public PaintTool ActiveTool
    {
        get => activeTool;
        set => SetProperty(ref activeTool, value);
    }

    public Color SelectedColor
    {
        get => selectedColor;
        set => SetProperty(ref selectedColor, value);
    }

    public Color BackgroundColor
    {
        get => backgroundColor;
        set => SetProperty(ref backgroundColor, value);
    }

    public string DefaultText
    {
        get => defaultText;
        set => SetProperty(ref defaultText, value);
    }

    public bool AutoFill
    {
        get => autoFill;
        set => SetProperty(ref autoFill, value);
    }

    public bool IsCircleRectMode
    {
        get => isCircleRectMode;
        set => SetProperty(ref isCircleRectMode, value);
    }

    public List<Color> Palette { get; } = [ Colors.Black, Colors.White, Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Purple, Colors.Orange,
        Colors.Gray, Colors.Brown, Colors.Cyan, Colors.Magenta, Colors.Lime, Colors.Maroon, Colors.Navy, Colors.Olive ];

    private static Color GetDefaultColor() => Colors.Black;

    public IRelayCommand SelectToolCommand => selectToolCommand ??= new RelayCommand<PaintTool>(SelectTool);

    public IRelayCommand SelectColorCommand => selectColorCommand ??= new RelayCommand<Color>(SelectColor);

    [RelayCommand]
    private void SetBackground()
    {
        BackgroundColor = SelectedColor;
    }

    private void SelectTool(PaintTool tool) => ActiveTool = tool;

    private void SelectColor(Color? color) => SelectedColor = color ?? GetDefaultColor();
}