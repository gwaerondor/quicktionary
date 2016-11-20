﻿using System;
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
        public ResultWindow(string text)
        {
            InitializeComponent();
            StartWebClient(text);
        }

        private void StartWebClient(string text)
        {
            TranslationClient client = new TranslationClient();
            string resultPage = client.Request(text);
            textBlock.Text = resultPage;
        }
    }
}
