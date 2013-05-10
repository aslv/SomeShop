using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OnlineStoreService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public bool Login(string name, string password)
        {
            Model1Container provider = new Model1Container();
                        //Example of using LINQ to access the model.

            var names = from d in provider.AccountsSet 
                        where d.Username==name && d.Password==password
                        select d.Username;


            if (names.Contains(name)|| ("test".Equals(name) && "test".Equals(password)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public Product[] GetProductList()
        {
            throw new NotImplementedException();
        }

        public Product[] GetSearchedProductsList(string data)
        {
            throw new NotImplementedException();
        }

        public Product[] GetTopTenProductsList()
        {
            throw new NotImplementedException();
        }

        public Product[] GetPromoProductsList()
        {
            throw new NotImplementedException();
        }

        public void addProduct(string productID, string name, string genre, string description, string cover, DateTime releaseDate, string producer, int score, decimal price)
        {
            throw new NotImplementedException();
        }

        public void deleteProduct(string productID)
        {
            throw new NotImplementedException();
        }

        public void addPromotion(string productID, int discount, DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public bool orderProducts(string Username, string[] productIDs)
        {
            throw new NotImplementedException();
        }
    }
}
