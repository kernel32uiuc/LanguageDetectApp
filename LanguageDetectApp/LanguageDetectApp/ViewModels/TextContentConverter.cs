﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Shapes;

namespace LanguageDetectApp.ViewModels
{
    class TextContentConverter : IValueConverter
    {
        private static string _default = "No Content Found";
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var words = value as ObservableCollection<KeyValuePair<string, Rectangle>>;
            if (words == null)
            {
                return _default;
            }
            string temp = String.Empty;
            var listwords = words.ToList().Select(word => word.Key);
            if (listwords.Any())
	        {
                temp = String.Join(" ", words.ToList().Select(word => word.Key));
                return temp;		 
	        }
            return _default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new ObservableCollection<KeyValuePair<string, Rectangle>>();
        }
    }
}
