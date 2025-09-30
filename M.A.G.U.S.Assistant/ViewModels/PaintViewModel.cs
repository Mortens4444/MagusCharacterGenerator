using M.A.G.U.S.Assistant.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace M.A.G.U.S.Assistant.ViewModels
{
    public class PaintViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> ShapeOptions { get; } = new ObservableCollection<string>
        {
            "Chair", "Table", "Wall", "GlassSphere", "Human"
        };

        public ObservableCollection<DrawableShape> Shapes { get; } = new ObservableCollection<DrawableShape>();

        private int selectedShapeIndex;
        public int SelectedShapeIndex
        {
            get => selectedShapeIndex;
            set
            {
                if (selectedShapeIndex == value) return;
                selectedShapeIndex = value;
                OnPropertyChanged(nameof(SelectedShapeIndex));
            }
        }

        private DrawableShape selectedShape;
        public DrawableShape SelectedShape
        {
            get => selectedShape;
            set
            {
                if (selectedShape == value) return;
                selectedShape = value;
                OnPropertyChanged(nameof(SelectedShape));
            }
        }

        private double shapeSize = 60;
        public double ShapeSize
        {
            get => shapeSize;
            set
            {
                if (Math.Abs(shapeSize - value) < 0.1) return;
                shapeSize = value;
                OnPropertyChanged(nameof(ShapeSize));
            }
        }

        private Color selectedColor = Colors.SaddleBrown;
        public Color SelectedColor
        {
            get => selectedColor;
            set
            {
                if (selectedColor == value) return;
                selectedColor = value;
                OnPropertyChanged(nameof(SelectedColor));
            }
        }

        public ICommand UndoCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand PickColorCommand { get; }

        public CanvasDrawable CanvasDrawable { get; }

        public PaintViewModel()
        {
            UndoCommand = new Command(() =>
            {
                if (Shapes.Any()) Shapes.RemoveAt(Shapes.Count - 1);
                CanvasDrawable.Invalidate();
            });

            ClearCommand = new Command(() =>
            {
                Shapes.Clear();
                CanvasDrawable.Invalidate();
            });

            PickColorCommand = new Command(async () =>
            {
                // egyszerű color picker modal (bővíthető)
                var page = new ContentPage { Title = "Pick color" };
                var picker = new Entry { Placeholder = "#AARRGGBB vagy név" };
                var ok = new Button { Text = "OK" };
                ok.Clicked += (s, e) =>
                {
                    try
                    {
                        var col = Color.FromArgb(picker.Text);
                        SelectedColor = col;
                    }
                    catch
                    {
                        // ignore invalid
                    }
                    Application.Current.MainPage.Navigation.PopModalAsync();
                };
                page.Content = new StackLayout { Padding = 12, Children = { picker, ok } };
                await Application.Current.MainPage.Navigation.PushModalAsync(page);
            });

            CanvasDrawable = new CanvasDrawable(this);
        }

        public void PlaceShape(double x, double y)
        {
            var typeName = ShapeOptions[Math.Max(0, Math.Min(ShapeOptions.Count - 1, SelectedShapeIndex))];
            var shape = new DrawableShape
            {
                Type = typeName,
                X = (float)x,
                Y = (float)y,
                Size = (float)ShapeSize,
                Color = SelectedColor,
            };

            Shapes.Add(shape);
            CanvasDrawable.Invalidate();
        }

        internal void Invalidate() => CanvasDrawable.Invalidate();

        private void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
