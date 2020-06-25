using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StorePOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ResourceDictionary myResourceDictionary = new ResourceDictionary();

        myResourceDictionary.
        Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);

        myResourceDictionary.Source = new Uri("Dictionary2.xaml", UriKind.Relative);
        Application.Current.Resources.MergedDictionaries.Add(myResourceDictionary);
    }
}
