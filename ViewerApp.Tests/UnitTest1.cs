using _3d_viewer.ViewModels;
using HelixToolkit.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Windows.Media.Media3D;
using ViewerApp.Models;
using ViewerApp.ViewModels;

namespace ViewerApp.Tests
{
    [TestClass]
    public class ViewerViewModelTests
    {
        [TestMethod]
        public void TestLoadModel_WhenModelIsLoaded_ShouldSetLoadedModel()
        {
            // Arrange
            var viewerViewModel = new ViewerViewModel();

            // Create a mock Model3DGroup to simulate loading a model
            var modelGroup = new Model3DGroup();
            modelGroup.Children.Add(new GeometryModel3D());  // Add a mock model to the group

            // Act: Set the LoadedModel directly to simulate loading a model
            viewerViewModel.LoadedModel = modelGroup;

            // Assert: Check that the LoadedModel is set correctly
            Assert.IsNotNull(viewerViewModel.LoadedModel);
            Assert.IsInstanceOfType(viewerViewModel.LoadedModel, typeof(Model3DGroup));
            Assert.AreEqual(1, (viewerViewModel.LoadedModel as Model3DGroup).Children.Count);

            // Act: Check if the CurrentModel is set from the first Model3D in the group
            viewerViewModel.LoadModel();

            // Assert: Check that CurrentModel is correctly set from the first Model3D in the group
            Assert.IsNotNull(viewerViewModel.CurrentModel);
            Assert.IsInstanceOfType(viewerViewModel.CurrentModel, typeof(MeshModel));
        }
    }
}
