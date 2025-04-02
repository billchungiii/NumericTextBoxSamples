using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace NumericTextBoxSample002
{
    public class NumericBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;
        }

        private void OnPreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]*$"); 
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
        }
    }
}
