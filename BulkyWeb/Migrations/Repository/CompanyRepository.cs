﻿using BulkyWeb.Data;
using BulkyWeb.Migrations.Repository.IRepository;
using BulkyWeb.Models;
using System.Linq.Expressions;

namespace BulkyWeb.Migrations.Repository
{
	public class CompanyRepository :  Repository<Company>,ICompanyRepository 
	{
		private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
        

		public void Update(Company obj)
		{
			_db.Companies.Update(obj);
		}
	}
}
