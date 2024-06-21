﻿using BulkyWeb.Data;
using BulkyWeb.Migrations.Repository.IRepository;
using System.Drawing.Printing;

namespace BulkyWeb.Migrations.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

		public ICompanyRepository Company { get; private set; }
		public IApplicationUserRepository ApplicationUser { get; private set; }
        public IShoppingCartRepository ShoppingCart {  get; private set; }
		public IOrderHeaderRepository OrderHeader { get; private set; }
		public IOrderDetailRepository OrderDetail { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
		{
			this._db = db;
			Category = new CategoryRepository(_db);
			Product = new ProductRepository(_db);
			Company = new CompanyRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db);
			ApplicationUser = new ApplicationUserRepository(_db);
			OrderHeader = new OrderHeaderRepository(_db);
			OrderDetail = new OrderDetailRepository(_db);
		}
		

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}