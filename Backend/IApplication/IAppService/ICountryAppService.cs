using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IApplication.IAppService
{
    public interface ICountryAppService
    {
        public Task<List<CountryDTO>> GetAllCountries();

    }
}
