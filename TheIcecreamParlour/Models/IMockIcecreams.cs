using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheIcecreamParlour.Models
{
    public interface IMockIcecreams
    {
        IQueryable<icecream> icecreams { get; }

        icecream Save(icecream icecream);

        void Delete(icecream icecream);

        void Dispose();
    }
}
