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

namespace Quicktionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool changeTriggeredFromInitialText;
        private bool shouldDisplayWatermark;
        private string initialMessage;

        public MainWindow()
        {
            this.shouldDisplayWatermark = true;
            this.changeTriggeredFromInitialText = true;
            InitializeComponent();
            Loaded += (sender, e) =>
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            this.initialMessage = inputBox.Text;
        }

        void EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                OpenResults();
                e.Handled = true;
            }
        }

        private void OpenResults()
        {
            ResultWindow results = new ResultWindow(inputBox.Text);
            results.Show();
            this.Close();   
        }

        private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changeTriggeredFromInitialText)
            {
                this.changeTriggeredFromInitialText = false;
            }
            else if (shouldDisplayWatermark)
            {
                inputBox.Clear();
                inputBox.Foreground = Brushes.Black;
                inputBox.FontStyle = FontStyles.Normal;
                this.shouldDisplayWatermark = false;
            }
        }
    }
}
