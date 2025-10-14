using M.A.G.U.S.Assistant.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels;

public class PaintWizardViewModel : INotifyPropertyChanged
{
    // alap: 1 px = 1 cm (pixelsPerCm = 1), a Zoom megszorozza
    private const int PixelsPerCmBase = 1;

    public ObservableCollection<PaletteItem> PaletteItems { get; } = new ObservableCollection<PaletteItem>();
    public ObservableCollection<PlacedItem> PlacedItems { get; } = new ObservableCollection<PlacedItem>();

    private double zoom = 1.0;
    public double Zoom
    {
        get => zoom;
        set
        {
            if (Math.Abs(zoom - value) < 0.001) return;
            zoom = value;
            OnPropertyChanged(nameof(Zoom));
            OnPropertyChanged(nameof(ScaleFactor));
        }
    }

    public double ScaleFactor => PixelsPerCmBase * Zoom;

    private string widthMeters = "5";
    public string WidthMeters
    {
        get => widthMeters;
        set
        {
            if (widthMeters == value) return;
            widthMeters = value ?? String.Empty;
            OnPropertyChanged(nameof(WidthMeters));
        }
    }

    private string heightMeters = "3";
    public string HeightMeters
    {
        get => heightMeters;
        set
        {
            if (heightMeters == value) return;
            heightMeters = value ?? String.Empty;
            OnPropertyChanged(nameof(HeightMeters));
        }
    }

    public double CanvasWidth => Math.Max(1, MetersToCmDouble(WidthMeters)) * ScaleFactor;
    public double CanvasHeight => Math.Max(1, MetersToCmDouble(HeightMeters)) * ScaleFactor;

    public string GridInfo => $"{MetersToCmInt(WidthMeters)}×{MetersToCmInt(HeightMeters)} cm";

    private string status = String.Empty;
    public string Status
    {
        get => status;
        set { status = value; OnPropertyChanged(nameof(Status)); }
    }

    public ICommand CreateGridCommand { get; }
    public ICommand ToggleDrawModeCommand { get; }
    public ICommand UndoCommand { get; }
    public ICommand ClearCommand { get; }

    public PaletteItem? SelectedPaletteItem { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    // occupancy: set of occupied cells in cm coordinates (x,y)
    private readonly HashSet<(float x, float y)> occupancy = new HashSet<(float x, float y)>();

    private readonly Stack<Action> undoStack = new Stack<Action>();

    public PaintWizardViewModel()
    {
        Zoom = 1.0;
        CreateGridCommand = new RelayCommand(_ => OnCreateGrid());
        ToggleDrawModeCommand = new RelayCommand(_ => ToggleDrawMode());
        UndoCommand = new RelayCommand(_ => Undo());
        ClearCommand = new RelayCommand(_ => Clear());

        SeedPalette();
    }

    private void SeedPalette()
    {
        PaletteItems.Add(new PaletteItem { Id = "plant1", Name = "Paradicsom", Image = "tomato.png", WidthCm = 30, HeightCm = 30 });
        PaletteItems.Add(new PaletteItem { Id = "plant2", Name = "Paprika", Image = "pepper.png", WidthCm = 30, HeightCm = 30 });
        PaletteItems.Add(new PaletteItem { Id = "bench", Name = "Pad", Image = "bench.png", WidthCm = 100, HeightCm = 40 });
        PaletteItems.Add(new PaletteItem { Id = "wall", Name = "Fal (ceruza)", Image = String.Empty, WidthCm = 10, HeightCm = 10 });
    }

    private bool isDrawingWalls;
    public bool IsDrawingWalls
    {
        get => isDrawingWalls;
        set { isDrawingWalls = value; OnPropertyChanged(nameof(IsDrawingWalls)); }
    }

    private void ToggleDrawMode() => IsDrawingWalls = !IsDrawingWalls;

    private void OnCreateGrid()
    {
        occupancy.Clear();
        PlacedItems.Clear();
        undoStack.Clear();
        OnPropertyChanged(nameof(CanvasWidth));
        OnPropertyChanged(nameof(CanvasHeight));
        OnPropertyChanged(nameof(GridInfo));
        Status = $"Tábla: {GridInfo}";
    }

    private void Undo()
    {
        if (!undoStack.Any()) return;
        var action = undoStack.Pop();
        action?.Invoke();
    }

    private void Clear()
    {
        PlacedItems.Clear();
        occupancy.Clear();
        undoStack.Clear();
    }

    public bool TryPlaceFromPalette(PaletteItem item, int xCm, int yCm)
    {
        if (item == null) return false;
        if (!CanPlace(item.WidthCm, item.HeightCm, xCm, yCm)) return false;

        var placed = new PlacedItem
        {
            PaletteItemId = item.Id,
            Width = item.WidthCm,
            Height = item.HeightCm,
            X = xCm,
            Y = yCm,
            //Image = item.Image
        };

        PlacedItems.Add(placed);
        MarkOccupied(placed, true);

        // undo
        undoStack.Push(() =>
        {
            PlacedItems.Remove(placed);
            MarkOccupied(placed, false);
        });

        Status = $"Elhelyezve: {item.Name} @ {xCm}cm × {yCm}cm";
        return true;
    }

    public bool CanPlace(int widthCm, int heightCm, int xCm, int yCm)
    {
        var w = Math.Max(0, widthCm);
        var h = Math.Max(0, heightCm);
        for (var xx = xCm; xx < xCm + w; xx++)
            for (var yy = yCm; yy < yCm + h; yy++)
            {
                if (xx < 0 || yy < 0) return false;
                if (xx >= MetersToCmInt(WidthMeters) || yy >= MetersToCmInt(HeightMeters)) return false;
                if (occupancy.Contains((xx, yy))) return false;
            }

        return true;
    }

    private void MarkOccupied(PlacedItem placed, bool occupy)
    {
        for (var xx = placed.X; xx < placed.X + placed.Width; xx++)
        {
            for (var yy = placed.Y; yy < placed.Y + placed.Height; yy++)
            {
                var key = (xx, yy);
                if (occupy)
                {
                    occupancy.Add(key);
                }
                else
                {
                    occupancy.Remove(key);
                }
            }
        }
    }

    // Wall drawing: toggle cell occupancy as wall cell
    public void ToggleWallCell(int xCm, int yCm)
    {
        if (xCm < 0 || yCm < 0) return;
        if (xCm >= MetersToCmInt(WidthMeters) || yCm >= MetersToCmInt(HeightMeters)) return;
        var key = (xCm, yCm);
        if (occupancy.Contains(key))
        {
            occupancy.Remove(key);
            // remove any placed item that fully covers cell? for simplicity skip
        }
        else
        {
            occupancy.Add(key);
            // represent as PlacedItem of type "wall"
            var p = new PlacedItem
            {
                PaletteItemId = "wall",
                X = xCm,
                Y = yCm,
                Width = 1,
                Height = 1,
                //Image = String.Empty
            };
            PlacedItems.Add(p);
            undoStack.Push(() =>
            {
                PlacedItems.Remove(p);
                occupancy.Remove(key);
            });
        }
    }

    #region Helpers
    private static int MetersToCmInt(string metersText)
    {
        return (int)Math.Max(0, Math.Floor(MetersToCmDouble(metersText)));
    }

    private static double MetersToCmDouble(string metersText)
    {
        if (double.TryParse(metersText, out var val))
        {
            return val * 100.0;
        }
        return 0.0;
    }

    private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    #endregion
}

// Minimal RelayCommand (ha nincs már a projektben)
public class RelayCommand : ICommand
{
    private readonly Action<object?> execute;
    private readonly Func<object?, bool>? canExecute;

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;
    public event EventHandler? CanExecuteChanged;
    public void Execute(object? parameter) => execute(parameter);
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
