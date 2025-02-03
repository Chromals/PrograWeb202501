using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ShipperDAL : DALGenericoImpl<Shipper>, IShipperDAL
    {
        private NorthWindContext _context;

        public ShipperDAL(NorthWindContext context): base(context)
        {
            _context = context;
        }

       
    }
}
