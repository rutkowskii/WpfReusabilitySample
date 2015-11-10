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

namespace WpfReusabilitySample
{
    /// <summary>
    /// Interaction logic for PrContainer.xaml
    /// </summary>
    public partial class PrContainer : UserControl
    {
        public PrContainer()
        {
            InitializeComponent();
        }


        public static DependencyProperty BackgroundProperty = DependencyProperty.Register("Background",
            typeof(System.Windows.Media.Brush),
            typeof(PrContainer));
        public static DependencyProperty TitleProperty = DependencyProperty.Register("Title",
           typeof(string),
           typeof(PrContainer), new PropertyMetadata("DEFAULT TITLE"));
        public static DependencyProperty ItemTemplateProperty = DependencyProperty.Register("ItemTemplate",
           typeof(DataTemplate),
           typeof(PrContainer));


        public Brush Background
        {
            get { return (Brush) GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
    }
}
