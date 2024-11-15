// ViewModels/ViewerViewModel.cs
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using Microsoft.Win32;
using ViewerApp.Models;
using ViewerApp.ViewModels;

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

        // Команда для завантаження 3D-моделі
        public ICommand LoadModelCommand { get; }

        public ViewerViewModel()
        {
            LoadModelCommand = new RelayCommand(LoadModel);
        }

        private void LoadModel()
        {
            // Використовуємо OpenFileDialog для вибору файлу моделі
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "OBJ Files (*.obj)|*.obj|FBX Files (*.fbx)|*.fbx|STL Files (*.stl)|*.stl|All Files (*.*)|*.*",
                Title = "Select a 3D Model File"
            };

            // Перевіряємо, чи був файл вибраний користувачем
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
                    // Обробка помилок, наприклад, показ повідомлення користувачу
                    System.Windows.MessageBox.Show($"Error loading model: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
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
