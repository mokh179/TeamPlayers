using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repos
{
    public class UnitOfWork:IUnitOfWork
    {
        AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }
        public IBase<Player> Players => new BaseRepo<Player>(_db);
        public IBase<Team> Teams => new BaseRepo<Team>(_db);

        public IBase<User> Users => new BaseRepo<User>(_db);

        public int complete()
        {
            return _db.SaveChanges();
        }
    }
}
