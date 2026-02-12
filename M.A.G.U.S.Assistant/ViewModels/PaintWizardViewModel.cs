using CommunityToolkit.Mvvm.Input;
using M.A.G.U.S.Assistant.Actions;
using M.A.G.U.S.Assistant.Database.Entities;
using M.A.G.U.S.Assistant.Database.Repositories;
using M.A.G.U.S.Assistant.Enums;
using M.A.G.U.S.Assistant.Interfaces;
using M.A.G.U.S.Assistant.Models.Drawing;
using M.A.G.U.S.Assistant.Services;
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
    private Color backgroundColor;
    private bool isColorPickerVisible = true;
    private bool isLeftSidebarVisible = true;
    private bool isSidebarVisible = true;
    private readonly DrawingRepository drawingRepository;
    private readonly Stack<IPaintAction> undoStack = new();
    private readonly Stack<IPaintAction> redoStack = new();
    public event EventHandler? RequestInvalidate;

    public PaintWizardViewModel(DrawingRepository drawingRepository)
    {
        this.drawingRepository = drawingRepository;
        DrawingLogic = new PaintCanvasDrawable { ViewModel = this };

        UndoCommand.NotifyCanExecuteChanged();
        RedoCommand.NotifyCanExecuteChanged();

        backgroundColor = SelectedColor;
        SetBackground();
        SelectColor(Colors.White);
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

    public bool IsColorPickerVisible
    {
        get => isColorPickerVisible;
        set => SetProperty(ref isColorPickerVisible, value);
    }

    public bool IsLeftSidebarVisible
    {
        get => isLeftSidebarVisible;
        set => SetProperty(ref isLeftSidebarVisible, value);
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
        var name = await ShellNavigationService.DisplayPromptAsync("Save", "Drawing name", "Save", "Cancel", initialValue: $"{Lng.Elem("Drawing")}_{DateTime.Now:yyyyMMdd_HHmm}").ConfigureAwait(true);

        if (String.IsNullOrWhiteSpace(name))
        {
            return;
        }

        await drawingRepository.SaveDrawingAsync(name, [.. Elements]).ConfigureAwait(true);
        await RefreshSavedDrawings().ConfigureAwait(false);
        await ShellNavigationService.DisplayAlertAsync("Save", "Painting succesfully saved!").ConfigureAwait(true);
    }

    [RelayCommand]
    public async Task DeleteDrawing(DrawingEntity drawing)
    {
        if (drawing == null)
        {
            return;
        }

        var confirmText = String.Format(Lng.Elem("Are you sure you want to delete '{0}'?"), drawing.Name);
        bool confirm = await ShellNavigationService.DisplayAlertAsync("Delete", confirmText, "Yes", "No").ConfigureAwait(true);
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
        bool confirm = await ShellNavigationService.DisplayAlertAsync("Load", confirmText, "Yes", "No").ConfigureAwait(true);
        if (confirm)
        {
            var loadedElements = await drawingRepository.GetDrawingByNameAsync(drawing.Name).ConfigureAwait(false);
            if (loadedElements != null)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Elements.Clear();
                    undoStack.Clear();
                    redoStack.Clear();
                    UndoCommand.NotifyCanExecuteChanged();
                    RedoCommand.NotifyCanExecuteChanged();
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

    public bool CanUndo => undoStack.Count > 0;

    public bool CanRedo => redoStack.Count > 0;

    [RelayCommand]
    public void ClearBoard()
    {
        Elements.Clear();
        undoStack.Clear();
        redoStack.Clear();

        UndoCommand.NotifyCanExecuteChanged();
        RedoCommand.NotifyCanExecuteChanged();
        RequestInvalidate?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void SetBackground()
    {
        var bgRect = new RectangleElement
        {
            Color = SelectedColor,
            FillColor = SelectedColor,
            Rect = new RectF(0, 0, 10000, 10000)
        };

        Elements.Add(bgRect);
        RegisterAction(new AddAction(bgRect));
        RequestInvalidate?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    private void ToggleColorPicker()
    {
        IsColorPickerVisible = !IsColorPickerVisible;
    }

    [RelayCommand]
    private void ToggleLeftSidebar()
    {
        IsLeftSidebarVisible = !IsLeftSidebarVisible;
    }

    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarVisible = !IsSidebarVisible;
    }

    [RelayCommand(CanExecute = nameof(CanUndo))]
    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            var action = undoStack.Pop();
            action.Undo(Elements);
            redoStack.Push(action);

            UndoCommand.NotifyCanExecuteChanged();
            RedoCommand.NotifyCanExecuteChanged();

            RequestInvalidate?.Invoke(this, EventArgs.Empty);
        }
    }

    [RelayCommand(CanExecute = nameof(CanRedo))]
    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            var action = redoStack.Pop();
            action.Redo(Elements);
            undoStack.Push(action);

            UndoCommand.NotifyCanExecuteChanged();
            RedoCommand.NotifyCanExecuteChanged();

            RequestInvalidate?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RegisterAction(IPaintAction action)
    {
        undoStack.Push(action);
        redoStack.Clear();

        OnPropertyChanged(nameof(CanUndo));
        OnPropertyChanged(nameof(CanRedo));
        
        UndoCommand.NotifyCanExecuteChanged();
        RedoCommand.NotifyCanExecuteChanged();
    }

    private static Color GetDefaultColor() => Colors.Black;

    private void SelectTool(PaintTool tool) => ActiveTool = tool;

    private void SelectColor(Color? color) => SelectedColor = color ?? GetDefaultColor();
}