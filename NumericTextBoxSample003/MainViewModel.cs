using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericTextBoxSample003
{
    public class MainViewModel : NotifyPropertyBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                SetProperty(ref _age, value);
            }
        }


    }
}
