using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Fitzhenry.Common;
using WpfMvvmNunitBase.Models;

namespace WpfMvvmNunitBase.ViewModels
{
    /// <summary>
    /// A ViewModel for the ExampleModel. Prepares ExampleModel data for display
    /// in the ExampleView.
    /// </summary>
    public class ExampleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ExampleModel _model = new ExampleModel();
        private readonly ICommand _addOne;
        private readonly ICommand _subtractOne;

        public ICommand AddOne
        {
            get { return _addOne; }
        }

        public ICommand SubtractOne
        {
            get { return _subtractOne; }
        }

        public int DisplayValue
        {
            get { return _model.CurValue; }
        }

        /// <summary>
        /// Formats the DisplayValue into nicer text. In this case, negative values 
        /// are displayed like this: (1)
        /// 
        /// You can do all kinds of more interesting formatting/pretty-printing/coloring/etc.
        /// like this in the ViewModel. The ViewModel simply prepares the Model data for 
        /// display in the View.
        /// </summary>
        public string DisplayText
        {
            get
            {
                if (this.DisplayValue < 0)
                {
                    return "(" + this.DisplayValue + ")";
                }
                else
                {
                    return this.DisplayValue.ToString();
                }
            }
        }

        public ExampleViewModel()
        {
            this._addOne = new AddOneCommand(this);
            this._subtractOne = new SubtractOneCommand(this);

            this._model.PropertyChanged += ModelOnPropertyChanged;
        }

        /// <summary>
        /// When a Model property changes, fire PropertyChanged events for any derived properties on this ViewModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="propertyChangedEventArgs"></param>
        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "CurValue":
                    this.PropertyChanged.Fire(this, "DisplayValue", "DisplayText");
                    break;
            }
        }

        /// <summary>
        /// A command for the AddOne action.
        /// </summary>
        public class AddOneCommand : ICommand
        {
            private readonly ExampleViewModel _viewModel;

            /// <summary>
            /// Pass in the outer class because C# doesn't provide
            /// automatic access to outer classes. You do, however, 
            /// get access to private properties of the outer class.
            /// </summary>
            /// <param name="viewModel">The outer class (a view model)</param>
            public AddOneCommand(ExampleViewModel viewModel)
            {
                this._viewModel = viewModel;
            }

            /// <summary>
            /// Insert logic here on whether or not the user should be able
            /// to execute the command. If CanExecute returns false, the button
            /// should appear disabled in the View.
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public bool CanExecute(object parameter)
            {
                return true;
            }

            /// <summary>
            /// Fires when the value of CanExecute changes to update the enabled/disabled
            /// state of a button, for example.
            /// </summary>
            public event EventHandler CanExecuteChanged;

            /// <summary>
            /// On Execute, run the method on the Model. Don't update the View directly.
            /// When the Model updates, the View will update automatically through
            /// PropertyChanged events.
            /// </summary>
            /// <param name="parameter"></param>
            public void Execute(object parameter)
            {
                _viewModel._model.Add(1);
            }
        }

        public class SubtractOneCommand : ICommand
        {
            private ExampleViewModel _viewModel;

            public SubtractOneCommand(ExampleViewModel viewModel)
            {
                this._viewModel = viewModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _viewModel._model.Add(-1);
            }
        }
    }
}
