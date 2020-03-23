using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace NumericTextBoxSample001
{
    internal class AgeValidationRule : ValidationRule
    {
        private BindingExpressionBase _owner;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {           
            var source = (string)value;
            if (string.IsNullOrEmpty(source))
            {
                return GetFalseResult("不可空白");
            }

            if (!int.TryParse(source, out int age))            
            {
                _owner.UpdateTarget();
                return GetFalseResult("非數字");
            }
            
            return new ValidationResult(true, null);
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo, BindingExpressionBase owner)
        {          
            _owner = owner;
           return Validate(value, cultureInfo);
        }


        private static ValidationResult GetFalseResult(string message)
        {
            return new ValidationResult(false, message);
        }
    }
}
