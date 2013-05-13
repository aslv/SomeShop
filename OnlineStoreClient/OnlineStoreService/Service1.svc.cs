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
        private Model1Container provider;
        Service1()
        {
            provider = new Model1Container();
        }
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

        public bool registerUser(string username, string password, bool type, DateTime dateOfBirth, bool gender, string email, string firstName, string lastName, bool role, decimal accBalance)
        {
            AccountsSet account = new AccountsSet();
            var products = from d in provider.AccountsSet
                           where d.Username == username
                           select d.Username;
            if (products.Contains(username))
            {
                return false;
            }
            account.Username = username;
            account.Password = password;
            account.Type = type;
            account.DateOfBirth = dateOfBirth;
            account.Gender = gender;
            account.email = email;
            account.FirstNameAcc = firstName;
            account.LastNameAcc = lastName;
            account.Role = role;
            account.AccBalance = accBalance;
            provider.AccountsSet.AddObject(account);
            return true;
        }
        public bool Login(string name, string password)
        {
            //Example of using LINQ to access the model.

            var names = from d in provider.AccountsSet
                        where d.Username == name && d.Password == password
                        select d.Username;


            if (names.Contains(name))
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
            var products = from d in provider.ProductsSet
                           select d;
            Product[] result = new Product[products.ToList().Count];
            List<ProductsSet> productList = products.ToList();
            productList = SetPromotionalPrices(productList);
            result = ConvertProductSetToProduct(productList);
            return result;
        }

        public Product[] GetSearchedProductsList(string data)
        {
            var products = from d in provider.ProductsSet
                           where d.ProductName.Contains(data)
                           select d;
            Product[] result = new Product[products.ToList().Count];
            List<ProductsSet> productList = products.ToList();
            productList = SetPromotionalPrices(productList);
            result = ConvertProductSetToProduct(productList);
            return result;
        }

        public Product[] GetTopTenProductsList()
        {
            throw new NotImplementedException();
        }

        public Product[] GetPromoProductsList()
        {
            var products = from d in provider.ProductsSet
                           join x in provider.Promos on d.ProductID equals x.ProductID
                           where x.BeginDate < DateTime.Now && x.EndDate > DateTime.Now
                           select d;
            Product[] result = new Product[products.ToList().Count];
            List<ProductsSet> productList = products.ToList();
            productList = SetPromotionalPrices(productList);
            result = ConvertProductSetToProduct(productList);
            return result;
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
        private Product[] ConvertProductSetToProduct(List<ProductsSet> source)
        {
            Product[] result = new Product[source.Count];
            for (int i = 0; i < source.Count; i++)
            {
                result[i] = new Product();
                result[i].ID = source[i].ProductID;
                result[i].Name = source[i].ProductName;
                result[i].Genre = source[i].Genre;
                result[i].Description = source[i].Description;
                result[i].Cover = source[i].Cover;
                result[i].Producer = source[i].Producer;
                result[i].Price = source[i].Price;
            }

            return result;
        }
        private List<ProductsSet> SetPromotionalPrices(List<ProductsSet> productList)
        {
            List<ProductsSet> result = productList;

            var promotions = from d in provider.ProductsSet
                           join x in provider.Promos on d.ProductID equals x.ProductID
                           select d;
            List<ProductsSet> promotionsList = promotions.ToList();

            var discounts = from d in provider.Promos
                            select d.Discount;
            List<short> discountsList = discounts.ToList();
            int index=0;
            for (int i = 0; i < promotionsList.Count; i++)
            {
                index = result.IndexOf(promotionsList[i]);
                result[index].Price = result[index].Price * discountsList[i] / 100;
            }
            return result;
        }



    }
}
