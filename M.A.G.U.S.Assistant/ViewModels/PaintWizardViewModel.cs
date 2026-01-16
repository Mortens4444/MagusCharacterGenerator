using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Database.Entities;
using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using Mtf.LanguageService.MAUI;
using System.Collections.ObjectModel;

namespace M.A.G.U.S.Assistant.ViewModels;

internal partial class PaintWizardViewModel : BaseViewModel
{
    private IRelayCommand? selectToolCommand;
    private IRelayCommand? selectColorCommand;
    private IDrawableElement? currentElement;
    private PaintTool activeTool = PaintTool.Pencil;
    private Color selectedColor = GetDefaultColor();
    private string defaultText = "𝕸.𝕬.𝕲.𝖀.𝕾. - Ҝ.Ա.ᚠ.Ᵽ.⅃.";
    private bool autoFill;
    private bool isCircleRectMode;
    private Color backgroundColor = Colors.White;
    private readonly DrawingRepository drawingRepository;
    private bool isSidebarVisible = true;

    public PaintWizardViewModel(DrawingRepository drawingRepository)
    {
        this.drawingRepository = drawingRepository;
        DrawingLogic = new PaintCanvasDrawable { ViewModel = this };

        //Task.Run(async () => await RefreshSavedDrawings());
    }

    public IDrawableElement? CurrentElement
    {
        get => currentElement;
        set => SetProperty(ref currentElement, value);
    }

    public PaintCanvasDrawable DrawingLogic { get; }

    public ObservableCollection<IDrawableElement> Elements { get; } = [];

    public ObservableCollection<DrawingEntity> SavedDrawings { get; } = [];

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

    public bool IsSidebarVisible
    {
        get => isSidebarVisible;
        set => SetProperty(ref isSidebarVisible, value);
    }

    public List<Color> Palette { get; } = [ Colors.Black, Colors.White, Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Purple, Colors.Orange,
        Colors.Gray, Colors.Brown, Colors.Cyan, Colors.Magenta, Colors.Lime, Colors.Maroon, Colors.Navy, Colors.Olive, Colors.SaddleBrown, Colors.Orchid,
        Colors.Salmon, Colors.Crimson ];

    [RelayCommand]
    public async Task RefreshSavedDrawings()
    {
        var drawings = await drawingRepository.GetAllDrawingsAsync().ConfigureAwait(false);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            SavedDrawings.Clear();
            foreach (var drawing in drawings)
            {
                SavedDrawings.Add(drawing);
            }
        });
    }

    [RelayCommand]
    public async Task SaveDrawing()
    {
        var name = await Shell.Current.DisplayPromptAsync(Lng.Elem("Save"), Lng.Elem("Drawing name"), Lng.Elem("Save"), Lng.Elem("Cancel"), initialValue: $"{Lng.Elem("Drawing")}_{DateTime.Now:yyyyMMdd_HHmm}").ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(name))
        {
            return;
        }

        await drawingRepository.SaveDrawingAsync(name, Elements.ToList()).ConfigureAwait(true);
        await RefreshSavedDrawings();
        await Shell.Current.DisplayAlertAsync(Lng.Elem("Save"), Lng.Elem("Painting succesfully saved!"), "OK").ConfigureAwait(true);
    }

    [RelayCommand]
    public async Task DeleteDrawing(DrawingEntity drawing)
    {
        if (drawing == null)
        {
            return;
        }

        var confirmText = String.Format(Lng.Elem("Are you sure you want to delete '{0}'?"), drawing.Name);
        bool confirm = await Shell.Current.DisplayAlertAsync(Lng.Elem("Delete"), confirmText, Lng.Elem("Yes"), Lng.Elem("No")).ConfigureAwait(true);
        if (confirm)
        {
            await drawingRepository.DeleteDrawingAsync(drawing.Name).ConfigureAwait(false);
            await RefreshSavedDrawings().ConfigureAwait(true);
        }
    }

    [RelayCommand]
    public async Task LoadDrawing(DrawingEntity drawing)
    {
        if (drawing == null)
        {
            return;
        }

        var confirmText = String.Format(Lng.Elem("Are you sure you want to load '{0}'?"), drawing.Name);
        bool confirm = await Shell.Current.DisplayAlertAsync(Lng.Elem("Load"), confirmText, Lng.Elem("Yes"), Lng.Elem("No")).ConfigureAwait(true);
        if (confirm)
        {
            var loadedElements = await drawingRepository.GetDrawingByNameAsync(drawing.Name).ConfigureAwait(false);
            if (loadedElements != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Elements.Clear();
                    foreach (var el in loadedElements)
                    {
                        Elements.Add(el);
                    }
                });
            }
        }
    }

    public IRelayCommand SelectToolCommand => selectToolCommand ??= new RelayCommand<PaintTool>(SelectTool);

    public IRelayCommand SelectColorCommand => selectColorCommand ??= new RelayCommand<Color>(SelectColor);

    [RelayCommand]
    private void SetBackground()
    {
        BackgroundColor = SelectedColor;
    }

    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarVisible = !IsSidebarVisible;
    }

    private static Color GetDefaultColor() => Colors.Black;

    private void SelectTool(PaintTool tool) => ActiveTool = tool;

    private void SelectColor(Color? color) => SelectedColor = color ?? GetDefaultColor();
}