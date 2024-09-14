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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal testPrincipal = 5000;
            decimal testRate = 0.05M;
            float testTime = 10;
            int testNumber = 12;
            InterestCalculatorServiceReference.InterestCalculationsClient client = new InterestCalculatorServiceReference.InterestCalculationsClient();
            
            decimal si = client.SimpleInterest(testPrincipal, testRate, testTime);
            decimal sp = client.SimplePlusPrincipalInterest(testPrincipal, testRate, testTime);
            decimal ci = client.CompoundInterest(testPrincipal, testRate, testTime, testNumber);
            decimal pc = client.PeriodicCompoundInterest(testPrincipal, testRate, testTime);

            //intBox (Top Listbox, blue)
            intBox.Items.Clear();
            intBox.Items.Add(new Label { Background = new SolidColorBrush(Colors.White), BorderBrush = new SolidColorBrush(Colors.Black), BorderThickness = new Thickness(1.0),  Content = "Interest Information" });
            intBox.Items.Add("Simple Interest: " + si);
            intBox.Items.Add("Simple Plus Principal Interest: " + sp);
            intBox.Items.Add("Compound Interest: " + ci);
            intBox.Items.Add("Periodic Compound Interest: " + pc);

            InterestCalculatorServiceReference.AllInterest allInterest = client.CalculateAll(testPrincipal, testRate, testTime, testNumber);
            decimal siAll = allInterest.SimpleInterestValue;
            decimal spAll = allInterest.SimplePlusPrincipalInterestValue;
            decimal ciAll = allInterest.CompoundInterestValue;
            decimal pcAll = allInterest.PeriodicCompoundInterestValue;

            //intHeader (left side, green)
            intHeader.Children.Clear();
            intHeader.Children.Add(new Label { Content = "Simple Interest" });
            intHeader.Children.Add(new Label { Content = "Simple Plus Principal Interest" });
            intHeader.Children.Add(new Label { Content = "Compound Interest" });
            intHeader.Children.Add(new Label { Content = "Periodic Compound Interest" });

            //intValue (right side, pink)
            intValue.Children.Clear();
            intValue.Children.Add(new Label { Content = siAll });
            intValue.Children.Add(new Label { Content = spAll });
            intValue.Children.Add(new Label { Content = ciAll });
            intValue.Children.Add(new Label { Content = pcAll });

        }
    }
}
