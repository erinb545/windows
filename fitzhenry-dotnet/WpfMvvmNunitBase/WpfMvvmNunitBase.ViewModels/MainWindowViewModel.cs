using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmNunitBase.ViewModels
{
    /// <summary>
    /// The root ViewModel for the application. Handles communication 
    /// between top-level Views.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The ViewModel for the ExampleView control.
        /// </summary>
        private readonly ExampleViewModel _exampleViewModel = new ExampleViewModel();

        public ExampleViewModel ExampleViewModel
        {
            get { return this._exampleViewModel; }
        }
    }
}
