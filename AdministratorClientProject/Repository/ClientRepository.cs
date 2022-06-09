using AdministratorClientProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorClientProject.Repository
{
    public class ClientRepository
    {
		private QuipuDbEntities DataContext;

		public ClientRepository()
		{
			DataContext = new QuipuDbEntities();
		}
        #region Get
        public Client Get(int id)
		{
			return DataContext.Clients.Find(id);
		}
        #endregion
        #region AddClient
        public void AddClient(Client AddClients)
		{
			if (AddClients != null)
			{
				DataContext.Clients.Add(AddClients);
				DataContext.SaveChanges();
			}
		}
		#endregion
		#region EditClient
		public void EditClient(Client Clients)
		{
			var FindClient = this.Get(Clients.PartyId);
			if (FindClient != null)
			{
				FindClient.FullName = Clients.FullName;
				FindClient.PartyCode = Convert.ToInt32(Clients.PartyCode);
				FindClient.TaxCode = Convert.ToInt32(Clients.TaxCode);
				FindClient.CountryCode = Clients.CountryCode;
				FindClient.ClientType = Clients.ClientType;
				DataContext.SaveChanges();
			}
		} 
		#endregion
		#region RemoveClient
		public void RemoveClient(int id)
		{
			var ClientObj = DataContext.Clients.Find(id);
			if (ClientObj != null)
			{
				DataContext.Clients.Remove(ClientObj);
				DataContext.SaveChanges();
			}
		}
		#endregion
	}
}
