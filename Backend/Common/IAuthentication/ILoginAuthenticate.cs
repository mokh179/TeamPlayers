using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IAuthentication
{
    public interface ILoginAuthenticate
    {
        Task<AuthenticationDTO> LogInAsync(LoginDTO lm);
    }
}
