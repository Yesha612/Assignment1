using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheIcecreamParlour.Models
{
    public class IDataIcecreams : IMockIcecreams
    {
        // db connection
        private DbModel db = new DbModel();

        public IQueryable<icecream> icecreams { get { return db.icecreams; } }

        public void Delete(icecream icecream)
        {
            db.icecreams.Remove(icecream);
            db.SaveChanges();
        }

        public icecream Save(icecream icecream)
        {
            if (icecream.FlavourID == 0)
            {
                db.icecreams.Add(icecream);
            }
            else
            {
                db.Entry(icecream).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return icecream;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}