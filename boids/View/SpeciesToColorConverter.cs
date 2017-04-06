using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model.Species;
using Model;
using System.Windows.Media;

namespace View
{
    class SpeciesToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boid = (Boid)value;
            if(boid.Species is HunterSpecies)
            {
                return Brushes.Red;
            }
            else
            {
                Console.WriteLine(value);
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
