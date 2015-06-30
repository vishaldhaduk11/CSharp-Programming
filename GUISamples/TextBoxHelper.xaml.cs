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

namespace GUISamples
{
    /// <summary>
    /// Interaction logic for TextBoxHelper.xaml
    /// </summary>
    public partial class TextBoxHelper : Window
    {
        public TextBoxHelper()
        {
            InitializeComponent();
            //LabelTest.Content = "Content from code behind";
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var value = (TextBox)sender;
            LabelTest.Content = value.Text;
        }

    }
}
