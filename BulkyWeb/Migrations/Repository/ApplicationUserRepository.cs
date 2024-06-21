using BulkyWeb.Data;
using BulkyWeb.Migrations.Repository.IRepository;
using BulkyWeb.Models;
using System.Linq.Expressions;

namespace BulkyWeb.Migrations.Repository
{
	public class ApplicationUserRepository :  Repository<ApplicationUser>, IApplicationUserRepository
    {
		private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        

    }
}
