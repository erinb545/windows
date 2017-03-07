using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitzhenry.Common
{
    public static class Extensions
    {
        public static void Fire(this PropertyChangedEventHandler handler, object sender, params string[] propertyNames)
        {
            if (handler != null)
            {
                propertyNames.ToList().ForEach(propertyName =>
                {
                    handler(sender, new PropertyChangedEventArgs(propertyName));
                });
            }
        }
    }
}
