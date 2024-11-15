using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Microsoft.Win32;
using ViewerApp.Models;
using ViewerApp.ViewModels;
using Xceed.Wpf.Toolkit; // Додайте це для доступу до ColorPicker

namespace _3d_viewer.ViewModels
{
    public class ViewerViewModel : INotifyPropertyChanged
    {
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

        private Color _modelColor = Colors.Gray; // Колір моделі за замовчуванням
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

        // Команди для завантаження моделі та вибору кольору
        public ICommand LoadModelCommand { get; }

        public ViewerViewModel()
        {
            LoadModelCommand = new RelayCommand(LoadModel);
        }

        private void LoadModel()
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
                    var modelImporter = new ModelImporter();
                    var model = modelImporter.Load(openFileDialog.FileName);
                    LoadedModel = model;
                    CurrentModel = new MeshModel(model);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Error loading model: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
