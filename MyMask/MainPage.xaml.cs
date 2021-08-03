using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyMask
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            txtIdenPrompt.Text = "____ ____ ___";
        }
    }
}
