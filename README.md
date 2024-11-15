# 3D Viewer Application

## Overview
This project is a **3D Viewer Application** developed using **C#** with **WPF** and the **HelixToolkit** library. The application allows users to load, view, and interact with 3D models in formats such as `.obj`, `.stl`, and `.fbx`. It supports changing the model's color and includes testing for core functionalities.

---

## Features

### 1. Model Loading
- Supports 3D file formats: `.obj`, `.stl`, `.fbx`.
- Users can load 3D models using an Open File Dialog.

### 2. Color Customization
- A **color picker** is integrated, allowing users to change the model's color dynamically.

### 3. 3D Visualization
- Leverages **HelixToolkit.Wpf** for rendering.
- Includes default lighting and perspective camera.

### 4. Commands and MVVM
- Implements **RelayCommand** for binding UI actions.
- Follows the **MVVM pattern** for clean separation of concerns.

### 5. Unit Testing
- Includes tests for loading models and updating the model state.

---

## Technical Details

### 1. Dependencies
- **HelixToolkit.Wpf**: For 3D rendering.
- **Xceed.Wpf.Toolkit**: For the color picker control.
- **MSTest**: For unit testing.

### 2. Structure
The project is organized as follows:
ViewerApp ├── Interfaces │ └── IModelImporter.cs ├── Models │ └── MeshModel.cs ├── 
ViewModels │ └── ViewerViewModel.cs │ └── RelayCommand.cs ├── Views │ └── 
MainWindow.xaml │ └── MainWindow.xaml.cs ├── Tests │ └── ViewerViewModelTests.cs ├── 
App.xaml ├── App.xaml.cs └── AssemblyInfo.cs


### 3. ViewModel
The `ViewerViewModel` handles:
- Model loading.
- Dynamic color changes.
- Data binding for UI components.

### 4. Unit Testing
The tests verify:
- Models are loaded correctly.
- Properties like `LoadedModel` and `CurrentModel` are updated appropriately.

---

## Setup and Usage

### 1. Prerequisites
- Install **.NET 6+** or compatible version.
- Install **Visual Studio** with WPF development tools.

### 2. Running the Application
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Run the application.

### 3. Running Tests
1. Open the `Test Explorer` in Visual Studio.
2. Run all tests to ensure functionality.

---

## Future Enhancements
- Add support for more 3D file formats.
- Implement rotation and zoom controls for the model.
- Add functionality to save changes to the loaded model.
- Enhance error handling for unsupported file types.
