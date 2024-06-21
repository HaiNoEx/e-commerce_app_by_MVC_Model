using BulkyWeb.Models;

namespace BulkyWeb.Migrations.Repository.IRepository
{
	public interface ICompanyRepository : IRepository<Company> 
	{
		void Update(Company obj);
		

	}
}
