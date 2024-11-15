using System.Windows.Media.Media3D;

namespace ViewerApp.Interfaces  // Use your project's appropriate namespace
{
    public interface IModelImporter
    {
        Model3D Load(string fileName);
    }
}
