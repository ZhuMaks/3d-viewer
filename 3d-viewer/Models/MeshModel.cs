using HelixToolkit.Wpf;  // Підключення HelixToolkit для роботи з 3D-об'єктами
using System.Windows.Media.Media3D;

namespace ViewerApp.Models
{
    public class MeshModel
    {
        public Model3D Model { get; set; }

        public MeshModel(Model3D model)
        {
            Model = model;
        }
    }
}
