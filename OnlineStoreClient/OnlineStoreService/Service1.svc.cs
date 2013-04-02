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
        private string name = "pesho";
        private string pass = "pesho";
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


        public bool login(string name, string password)
        {
            Model1Container provider = new Model1Container();
                        //Example of using LINQ to access the model.
            //var names = from d in provider.Entity1Set
            //            where d.Id > 20
            //            select d;

            if (name == this.name && password == this.pass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
