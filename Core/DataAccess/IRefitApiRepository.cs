using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IRefitApiRepository
    {
        T GetClientService<T>();
    }
}
