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
    private string defaultText = "M.A.G.U.S.";

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

    public string DefaultText
    {
        get => defaultText;
        set => SetProperty(ref defaultText, value);
    }

    public List<Color> Palette { get; } = [ Colors.Black, Colors.White, Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Purple, Colors.Orange,
        Colors.Gray, Colors.Brown, Colors.Cyan, Colors.Magenta, Colors.Lime, Colors.Maroon, Colors.Navy, Colors.Olive ];

    private static Color GetDefaultColor() => Colors.Black;

    public IRelayCommand SelectToolCommand => selectToolCommand ??= new RelayCommand<PaintTool>(SelectTool);

    public IRelayCommand SelectColorCommand => selectColorCommand ??= new RelayCommand<Color>(SelectColor);

    private void SelectTool(PaintTool tool) => ActiveTool = tool;

    private void SelectColor(Color? color) => SelectedColor = color ?? GetDefaultColor();
}