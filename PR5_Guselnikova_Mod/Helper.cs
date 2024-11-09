using PR5_Guselnikova_Mod.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR5_Guselnikova_Mod
{
    public class Helper
    {
        private static Real_Estate_AgencyEntities _context;

        public static Real_Estate_AgencyEntities GetContext()
        {
            if (_context == null)
            {
                _context = new Real_Estate_AgencyEntities();
            }
            return _context;
        }
    }
}
