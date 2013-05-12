using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OnlineStoreService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        /// <summary>
        /// Triggered when a client tries to log in.
        /// </summary>
        /// <param name="name">The username the client sent</param>
        /// <param name="password">The password the client sent</param>
        /// <returns>True if the username/password combination is valid, false if not</returns>
        [OperationContract]
        bool Login(string name, string password);
        /// <summary>
        /// Triggered when a client presses the products (OR GAME ?!?!) tab.
        /// </summary>
        /// <returns>An array of products containing product name, genre, description, cover, producer and price</returns>
        [OperationContract]
        Product[] GetProductList();

        /// <summary>
        /// Triggered when a client uses the "Search the store" function (Control name=TxSearch).
        /// </summary>
        /// <returns>An array of products containing product name, genre, description, cover, producer and price, with each product's name, description, producer or genre
        /// matching the data string (only 1 is enough, not all)</returns>
        [OperationContract]
        Product[] GetSearchedProductsList(string data);

        /// <summary>
        /// Triggered when a client presses the Top10 tab.
        /// </summary>
        /// <returns>An array containig the 10 products with highest scores, containing product name, genre, description, cover, producer and price</returns>
        [OperationContract]
        Product[] GetTopTenProductsList();

        /// <summary>
        /// Triggered when a client presses the Promo tab.
        /// </summary>
        /// <returns>An array containig all promotional products, containing product name, genre, description, cover, producer and price</returns>
        [OperationContract]
        Product[] GetPromoProductsList();

        /// <summary>
        /// Triggered when an admin uses the "Add new game" function. Adds a new product to the database.
        /// </summary>
        /// <param name="productID">The id of the product</param>
        /// <param name="name">The name of the product</param>
        /// <param name="genre">The genre of the product</param>
        /// <param name="description">The description of the product</param>
        /// <param name="cover">The cover of the product</param>
        /// <param name="releaseDate">The release date of the product</param>
        /// <param name="producer">The producer of the product</param>
        /// <param name="score">The score of the product</param>
        /// <param name="price">The price of the product</param>
        [OperationContract]
        void addProduct(string productID, string name, string genre, string description, string cover, DateTime releaseDate, string producer, int score, decimal price);

        /// <summary>
        /// Remove the product with the specified id from the database.
        /// </summary>
        /// <param name="productID">The ID of the product to be removed</param>
        [OperationContract]
        void deleteProduct(string productID);

        /// <summary>
        /// Triggered when an admin uses the "Add a promotion" function.
        /// </summary>
        /// <param name="productID">The id of the product</param>
        /// <param name="discount">The discount price of the product</param>
        /// <param name="beginDate">The starting date of the promotion</param>
        /// <param name="endDate">Th end date of the promotion</param>
        [OperationContract]
        void addPromotion(string productID, int discount, DateTime beginDate, DateTime endDate);

        /// <summary>
        /// Triggered when a user makes an order.
        /// </summary>
        /// <param name="Username">The username of the user, making the order</param>
        /// <param name="productIDs">Array of products ids to be ordered</param>
        /// <returns>true if succesful, false if not</returns>
        [OperationContract]
        bool orderProducts(string Username, string[] productIDs);
        /// <summary>
        /// Registering user
        /// </summary>
        /// <returns>true if succesful, false if not</returns>
        [OperationContract]
        bool registerUser(string username, string password, bool type, DateTime dateOfBirth, bool gender, string email,string firstName, string lastName, bool role, decimal accBalance );

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    [DataContract]
    public class Product
    {
        private string productID;
        private string productName;
        private string genre;
        private string description;
        private string cover;
        private string producer;
        private decimal price;
        [DataMember]
        public string ID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string Name
        {
            get { return productName; }
            set { productName = value; }
        }
        [DataMember]
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        [DataMember]
        public string Cover
        {
            get { return cover; }
            set { cover = value; }
        }
        [DataMember]
        public string Producer
        {
            get { return producer; }
            set { producer = value; }
        }
        [DataMember]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
