using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.IAppService.Authentication
{
    public interface ILoginAppService
    {
        public Task<AuthenticationDTO> LoginUser();

    }
}
