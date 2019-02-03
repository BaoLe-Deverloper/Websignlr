using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSignalr.Models
{
    public class System_Model
    {
        private static System_Model instance;
        public static System_Model Instance
        {
            set
            {
                instance = value;
            }
            get
            {
                if (instance == null)
                    return new System_Model();
                else return instance;
            }
        }
        DataContext webData;
        public System_Model()
        {
            webData = new DataContext();
        }

        
        public void SetIsOnlineUserByID(string ID)
        {
            try
            {
                webData.Accounts.SingleOrDefault(q => q.AccountID == ID).Account_IsOnline = true;
                webData.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void SetIsOfflineUserByID(string ID)
        {
            try
            {
                webData.Accounts.SingleOrDefault(q => q.AccountID == ID).Account_IsOnline = false;
                webData.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}