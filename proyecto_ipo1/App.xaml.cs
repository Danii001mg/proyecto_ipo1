using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace proyecto_ipo1
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void SelectCulture(string culture)
        {
            if (String.IsNullOrEmpty(culture))
                return;
            // Copiamos todos los diccionarios de recursos en una lista auxiliar
            var dictionaryList = Application.Current.Resources.MergedDictionaries.ToList();
            // Buscamos el idioma (culture) especifico entre ellos
            string requestedCulture = string.Format("DiccionarioRecursos.{0}.xaml", culture);
            var resourceDictionary = dictionaryList.
            FirstOrDefault(d => d.Source.Equals("recursos/" + requestedCulture));
            if (resourceDictionary == null)
            {
                // Si no lo encontramos, aplicamos el idioma por defecto
                requestedCulture = "DiccionarioRecursos.xaml";
                resourceDictionary = dictionaryList.
                FirstOrDefault(d => d.Source.OriginalString == requestedCulture);
            }
            // Si lo encontramos, lo borramos de la lista y lo posicionamos el ultimo
            // Utilizamos las cadenas de este diccionario
            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
            // Informamos del idioma que estamos utilizando actualmente
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}

