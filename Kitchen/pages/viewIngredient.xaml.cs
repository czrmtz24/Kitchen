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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kitchen.pages
{
    /// <summary>
    /// Interaction logic for viewIngredient.xaml
    /// </summary>
    public partial class viewIngredient : Page
    {
        public event EventHandler PageFinished;
        public string ingredientName;
        public viewIngredient()
        {
            InitializeComponent();
        }

    }
}
