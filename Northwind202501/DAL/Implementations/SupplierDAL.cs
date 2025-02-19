using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class SupplierDAL: DALGenericoImpl<Supplier>, ISupplierDAL   
    {
        NorthWindContext _context;

        public SupplierDAL(NorthWindContext context): base(context)
        {
            _context = context;
        }
        

    }
}
