using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppService
{
    public class CountryAppService : BaseAppservice, ICountryAppService
    {
        public CountryAppService(IUnitOfWork Theunitofwork) : base(Theunitofwork)
        {
        }

        public async Task<List<CountryDTO>> GetAllCountries()
        {
            List<CountryDTO> Countries=new List<CountryDTO>();
            try
            {
                var PlayersList = await _Theunitofwork.Countries.getAll();
                foreach (var item in PlayersList)
                {
                    Countries.Add(new CountryDTO() { countryId=item.countryId,countryName=item.countryName});
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Countries;
        }
    }
}
