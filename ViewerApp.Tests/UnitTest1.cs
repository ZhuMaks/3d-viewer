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
        public void TestLoadModel_ShouldSetLoadedModel()
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
        }

        [TestMethod]
        public void TestLoadedModel_ShouldContainModel3DGroupChildren()
        {
            // Arrange
            var viewerViewModel = new ViewerViewModel();

            // Create a mock Model3DGroup with one child to simulate a loaded model
            var modelGroup = new Model3DGroup();
            modelGroup.Children.Add(new GeometryModel3D());  // Add a mock model to the group

            // Act: Set the LoadedModel directly to simulate loading a model
            viewerViewModel.LoadedModel = modelGroup;

            // Assert: Ensure the LoadedModel has children
            var loadedModelGroup = viewerViewModel.LoadedModel as Model3DGroup;
            Assert.IsNotNull(loadedModelGroup);
            Assert.AreEqual(1, loadedModelGroup.Children.Count);
        }

        [TestMethod]
        public void TestLoadModel_ShouldSetCurrentModel()
        {
            // Arrange
            var viewerViewModel = new ViewerViewModel();

            // Create a mock Model3DGroup with one child to simulate a loaded model
            var modelGroup = new Model3DGroup();
            modelGroup.Children.Add(new GeometryModel3D());  // Add a mock model to the group

            // Act: Set the LoadedModel directly to simulate loading a model
            viewerViewModel.LoadedModel = modelGroup;

            // Act: Trigger LoadModel to set the CurrentModel
            viewerViewModel.LoadModel();

            // Assert: Ensure the CurrentModel is set correctly
            Assert.IsNotNull(viewerViewModel.CurrentModel);
            Assert.IsInstanceOfType(viewerViewModel.CurrentModel, typeof(MeshModel));
        }

        [TestMethod]
        public void TestLoadModel_WhenModelIsLoaded_ShouldAssignMeshModelToCurrentModel()
        {
            // Arrange
            var viewerViewModel = new ViewerViewModel();

            // Create a mock Model3DGroup with one child to simulate a loaded model
            var modelGroup = new Model3DGroup();
            modelGroup.Children.Add(new GeometryModel3D());  // Add a mock model to the group

            // Act: Set the LoadedModel directly to simulate loading a model
            viewerViewModel.LoadedModel = modelGroup;

            // Act: Load the model and check if CurrentModel is updated correctly
            viewerViewModel.LoadModel();

            // Assert: The CurrentModel should be a MeshModel instance
            Assert.IsNotNull(viewerViewModel.CurrentModel);
            Assert.IsInstanceOfType(viewerViewModel.CurrentModel, typeof(MeshModel));
        }
    }
}
