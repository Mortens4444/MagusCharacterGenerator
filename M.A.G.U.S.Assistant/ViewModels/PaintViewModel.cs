//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Windows.Input;

//namespace M.A.G.U.S.Assistant.ViewModels
//{
//    internal class PaintViewModel : BaseViewModel
//    {
//        public ObservableCollection<ItemOption> ItemOptions { get; } = new ObservableCollection<ItemOption>
//        {
//            new ItemOption { Name = "Chair", Icon = "chair_top.png" },
//            new ItemOption { Name = "Table", Icon = "table_top.png" },
//            new ItemOption { Name = "Carpet", Icon = "rug_top.png" },
//            new ItemOption { Name = "Shelf", Icon = "shelf_top.png" },
//            new ItemOption { Name = "Door", Icon = "door_top.png" }
//        };

//        public ObservableCollection<PlacedItem> PlacedItems { get; } = new ObservableCollection<PlacedItem>();

//        private int selectedModeIndex;
//        public ObservableCollection<string> Modes { get; } = new ObservableCollection<string> { "Place", "Draw", "Select" };
//        public int SelectedModeIndex
//        {
//            get => selectedModeIndex;
//            set
//            {
//                if (selectedModeIndex == value) return;
//                selectedModeIndex = value;
//                OnPropertyChanged();
//            }
//        }

//        private ItemOption selectedItemOption;
//        public ItemOption SelectedItemOption
//        {
//            get => selectedItemOption;
//            set
//            {
//                if (selectedItemOption == value) return;
//                selectedItemOption = value;
//                OnPropertyChanged();
//            }
//        }

//        private double shapeSize = 80;
//        public double ShapeSize
//        {
//            get => shapeSize;
//            set
//            {
//                if (Math.Abs(shapeSize - value) < 0.1) return;
//                shapeSize = value;
//                OnPropertyChanged();
//            }
//        }

//        private Color selectedColor = Colors.White;
//        public Color SelectedColor
//        {
//            get => selectedColor;
//            set
//            {
//                if (selectedColor == value) return;
//                selectedColor = value;
//                OnPropertyChanged();
//            }
//        }

//        public ICommand PickPresetColorCommand { get; }
//        public ICommand OpenColorPickerCommand { get; }
//        public ICommand UndoCommand { get; }
//        public ICommand ClearCommand { get; }

//        public GraphicsCanvasDrawable CanvasDrawable { get; }

//        // For simple drawing mode
//        public ObservableCollection<PointF> CurrentStroke { get; } = new ObservableCollection<PointF>();

//        // last touch used by tap fallback
//        public Point? LastTouch { get; private set; }

//        // manipulation temp variables
//        private PlacedItem hotItem;

//        public PaintViewModel()
//        {
//            PickPresetColorCommand = new Command<string>(p =>
//            {
//                // prefer explicit mapping instead of non-existent FromName
//                SelectedColor = p switch
//                {
//                    "Black" => Colors.Black,
//                    "White" => Colors.White,
//                    "SaddleBrown" => Colors.SaddleBrown,
//                    "Red" => Colors.Red,
//                    "Orange" => Colors.Orange,
//                    "Yellow" => Colors.Yellow,
//                    "Green" => Colors.Green,
//                    "Blue" => Colors.Blue,
//                    "Purple" => Colors.Purple,
//                    _ when !string.IsNullOrEmpty(p) && p.StartsWith("#") => Color.FromArgb(p),
//                    _ => SelectedColor
//                };
//            });

//            OpenColorPickerCommand = new Command(async () =>
//            {
//                var page = new ContentPage { Title = "Pick color" };
//                var entry = new Entry { Placeholder = String.Empty };
//                var ok = new Button { Text = "OK" };
//                ok.Clicked += (s, e) =>
//                {
//                    try
//                    {
//                        SelectedColor = Color.FromArgb(entry.Text);
//                    }
//                    catch
//                    {
//                    }
//                    Shell.Current.Navigation.PopModalAsync();
//                };
//                page.Content = new StackLayout { Padding = 12, Children = { entry, ok } };
//                await Shell.Current.Navigation.PushModalAsync(page);
//            });

//            UndoCommand = new Command(() =>
//            {
//                if (PlacedItems.Any()) PlacedItems.RemoveAt(PlacedItems.Count - 1);
//                CanvasDrawable.Invalidate();
//            });

//            ClearCommand = new Command(() =>
//            {
//                PlacedItems.Clear();
//                CanvasDrawable.ClearStrokes();
//                CanvasDrawable.Invalidate();
//            });

//            CanvasDrawable = new GraphicsCanvasDrawable(this);
//        }

//        public void RecordTouch(double x, double y)
//        {
//            LastTouch = new Point(x, y);
//        }

//        public void PlaceItem(double x, double y)
//        {
//            if (SelectedModeIndex == 1) // Draw mode
//            {
//                // start a stroke
//                CurrentStroke.Clear();
//                CurrentStroke.Add(new PointF((float)x, (float)y));
//                CanvasDrawable.Invalidate();
//                return;
//            }

//            var option = SelectedItemOption ?? ItemOptions.FirstOrDefault();
//            if (option == null) return;

//            var item = new PlacedItem
//            {
//                Icon = option.Icon,
//                X = (float)x,
//                Y = (float)y,
//                Width = (float)ShapeSize,
//                Height = (float)ShapeSize,
//                Rotation = 0f
//            };
//            PlacedItems.Add(item);
//            CanvasDrawable.Invalidate();
//        }

//        public void HandlePan(float deltaX, float deltaY)
//        {
//            // move hotItem while panning
//            if (hotItem == null)
//            {
//                // hit test last touch to select an item
//                hotItem = FindItemUnderLastTouch();
//            }

//            if (hotItem != null)
//            {
//                hotItem.X += deltaX;
//                hotItem.Y += deltaY;
//                CanvasDrawable.Invalidate();
//            }
//        }

//        public void HandlePinch(float scale)
//        {
//            if (hotItem == null) hotItem = FindItemUnderLastTouch();
//            if (hotItem == null) return;
//            hotItem.Width *= scale;
//            hotItem.Height *= scale;
//            CanvasDrawable.Invalidate();
//        }

//        public void EndManipulation()
//        {
//            hotItem = null;
//        }

//        private PlacedItem FindItemUnderLastTouch()
//        {
//            if (!LastTouch.HasValue) return null;
//            var p = LastTouch.Value;
//            // search from top-most (last) to first
//            for (var i = PlacedItems.Count - 1; i >= 0; i--)
//            {
//                var it = PlacedItems[i];
//                var left = it.X - it.Width / 2;
//                var top = it.Y - it.Height / 2;
//                if (p.X >= left && p.X <= left + it.Width && p.Y >= top && p.Y <= top + it.Height)
//                    return it;
//            }
//            return null;
//        }

//        public void Invalidate()
//        {
//            CanvasDrawable?.Invalidate();
//        }
//    }

//    public class ItemOption
//    {
//        public string Name { get; set; }
//        public string Icon { get; set; }
//    }

//    public class PlacedItem
//    {
//        public string PaletteItemId { get; set; }
//        public string Icon { get; set; }
//        public float X { get; set; }
//        public float Y { get; set; }
//        public float Width { get; set; }
//        public float Height { get; set; }
//        public float Rotation { get; set; }
//        public Microsoft.Maui.Graphics.IImage Image { get; internal set; }
//    }
//}