using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppService
{
    public class BaseAppservice
    {
        public IUnitOfWork _Theunitofwork;
        public BaseAppservice(IUnitOfWork Theunitofwork)
        {
            _Theunitofwork= Theunitofwork;
        }

    }
}
