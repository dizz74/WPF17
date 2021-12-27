using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF17
{
    /// <summary>
    /// Interaction logic for ColorSelector.xaml
    /// </summary>
    public partial class ColorSelector : UserControl
    {
        public static DependencyProperty ColorProperty;
         

        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;


        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        static ColorSelector()
        {
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorSelector),
             new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorSelector),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorSelector),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorSelector),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        }

        private static void OnColorRGBChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorSelector colorSelector = (ColorSelector)d;
            Color color = colorSelector.Color;
            if (e.Property.Equals(RedProperty))
                color.R = (byte)e.NewValue;
            else if (e.Property.Equals(GreenProperty))
                color.G = (byte)e.NewValue;
            else if (e.Property.Equals(BlueProperty))
                color.B = (byte)e.NewValue;

            colorSelector.Color = color;

        }
        private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

                Color newColor = (Color)e.NewValue;
                ColorSelector colorSelector = (ColorSelector)d;
                colorSelector.Red = newColor.R;
                colorSelector.Green = newColor.G;
                colorSelector.Blue = newColor.B;
            
        }

        public ColorSelector()
        {
            InitializeComponent();
        }
    }
}
