using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace Quicktionary
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow(String text, ChineseDictionary dictionary)
        {
            InitializeComponent();
            String result = DoDictionaryLookup(text, dictionary);
            textBlock.Text = result;
        }

        private String DoDictionaryLookup(String query, ChineseDictionary dictionary)
        {
            ArrayList hits = dictionary.Query(query);
            String result = "";
            foreach (DictionaryEntry e in hits)
            {
                result = result + e.ToString() + "\n";
            }
            return result;
        }
    }
}
