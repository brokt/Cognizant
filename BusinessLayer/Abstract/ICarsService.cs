using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarsService
    {
        List<Cars> GetList();
        Cars Add(Cars cars);
        Cars Update(Cars cars);
        void Delete(Cars cars);
    }
}
