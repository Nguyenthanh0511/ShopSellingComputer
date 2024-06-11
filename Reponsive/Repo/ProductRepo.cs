using Model.Entity;
using ServiceComputer.Model.DataModel;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceComputer.Reponsive.Repo
{
    public class ProductRepo : Reponsive<Product>,IProductRepo
    {
        public ProductRepo(DBServiceComputerContext context) : base(context)
        {
        }
    }
}
