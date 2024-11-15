using HelixToolkit.Wpf;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using ViewerApp.Models;
using ViewerApp.ViewModels;

namespace _3d_viewer.ViewModels
{
    public class ViewerViewModel : INotifyPropertyChanged
    {
        private readonly ModelImporter _modelImporter; // Direct use of ModelImporter
        private MeshModel _currentModel;

        public MeshModel CurrentModel
        {
            get => _currentModel;
            set
            {
                _currentModel = value;
                OnPropertyChanged();
            }
        }

        private Model3D _loadedModel;

        public Model3D LoadedModel
        {
            get => _loadedModel;
            set
            {
                _loadedModel = value;
                OnPropertyChanged();
            }
        }

        private Color _modelColor = Colors.Gray; // Default model color

        public Color ModelColor
        {
            get => _modelColor;
            set
            {
                _modelColor = value;
                ChangeModelColor(value);
                OnPropertyChanged();
            }
        }

        // Command for loading models
        public ICommand LoadModelCommand { get; }

        // Constructor
        public ViewerViewModel()
        {
            _modelImporter = new ModelImporter(); // Use ModelImporter directly
            LoadModelCommand = new RelayCommand(LoadModel);
        }

        // Loads a model using a file dialog
        internal void LoadModel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "OBJ Files (*.obj)|*.obj|FBX Files (*.fbx)|*.fbx|STL Files (*.stl)|*.stl|All Files (*.*)|*.*",
                Title = "Select a 3D Model File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Load model directly
                    var model = _modelImporter.Load(openFileDialog.FileName);
                    LoadedModel = model;

                    // If it's a Model3DGroup, we can extract the first Model3D from it
                    if (model is Model3DGroup modelGroup)
                    {
                        // Extract the first Model3D from the group
                        CurrentModel = new MeshModel(modelGroup.Children.FirstOrDefault() as Model3D);
                    }
                    else
                    {
                        CurrentModel = new MeshModel(model);
                    }
                }
                catch (Exception ex)
                {
                    // Show error message if loading fails
                    System.Windows.MessageBox.Show($"Error loading model: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
        }

        // Change the color of the loaded model
        private void ChangeModelColor(Color color)
        {
            var colorBrush = new SolidColorBrush(color);
            if (LoadedModel is Model3DGroup modelGroup)
            {
                foreach (var model in modelGroup.Children)
                {
                    if (model is GeometryModel3D geometryModel)
                    {
                        geometryModel.Material = new DiffuseMaterial(colorBrush);
                    }
                }
            }
        }

        // PropertyChanged event for notifying UI about property changes
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
