using AdministratorClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorClientProject.ViewModel.Register
{
    public class RegisterRepository
    {
		private QuipuDbEntities DataContext;
		public RegisterRepository()
        {
			DataContext = new QuipuDbEntities();

		}
		public void AddUser(Administrator AddUsers)
		{
			if (AddUsers != null)
			{
				DataContext.Administrators.Add(AddUsers);
				DataContext.SaveChanges();
			}
		}
	}
}
