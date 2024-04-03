using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

namespace BgLabelControlApp
{
    public sealed class BgLabelControl : Control
    {
        public BgLabelControl()
        {
            this.DefaultStyleKey = typeof(BgLabelControl);
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        DependencyProperty LabelProperty = DependencyProperty.Register(
                    nameof(Label),
                    typeof(string),
                    typeof(BgLabelControl),
                    new PropertyMetadata(default(string), new PropertyChangedCallback(OnLabelChanged)));

        public bool HasLabelValue { get; set; }

        private static void OnLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BgLabelControl labelControl = d as BgLabelControl; //null checks omitted
            String s = e.NewValue as String; //null checks omitted
            if (s == String.Empty)
            {
                labelControl.HasLabelValue = false;
            }
            else
            {
                labelControl.HasLabelValue = true;
            }
        }
    }
}
