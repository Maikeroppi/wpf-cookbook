using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CH01.CustomMarkupExtension
{
    public class RandomExtension : MarkupExtension
    {
        readonly int _from, _to;
        static readonly Random _rnd = new Random();
        public RandomExtension(int from, int to)
        {
            _from = from; _to = to;
        }
        public RandomExtension(int to) : this(0, to)
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return (double)_rnd.Next(_from, _to);
        }
    }
}
