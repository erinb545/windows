using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitzhenry.Common;

namespace WpfMvvmNunitBase.Models
{
    public class ExampleModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _curValue = 0;

        public int CurValue
        {
            get { return _curValue; }
            set
            {
                this._curValue = value;

                // Fire PropertyChanged on Set so that the View will be updated.
                this.PropertyChanged.Fire(this, "CurValue");
            }
        }

        public ExampleModel(int initialValue = 0)
        {
            this._curValue = initialValue;
        }

        public void Add(int value)
        {
            // Be sure to use the Setter so that the PropertyChanged event is fired.
            this.CurValue += value;
        }

    }
}
