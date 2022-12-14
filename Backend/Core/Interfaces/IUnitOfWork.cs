using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBase<Player> Players { get; }
        IBase<Team> Teams { get; }
        IBase<Country> Countries { get; }
        int complete();
    }
}
