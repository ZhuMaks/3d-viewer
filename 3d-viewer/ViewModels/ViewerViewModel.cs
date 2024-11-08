using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
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
            var modelImporter = new ModelImporter();
            var model = modelImporter.Load("D:\\CollegeEdu\\viewer_wpf\\3d-viewer\\3d-viewer\\49-sting-sword-lowpoly.obj\\Sting-Sword-lowpoly.obj");  // Замість "path_to_model.obj" використайте шлях до вашої моделі
            LoadedModel = model;
            CurrentModel = new MeshModel(model);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
