using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineStoreService;

namespace OnlineStoreTests
{
    [TestClass]
    public class TestLogin
    {
        private OnlineStoreService.Service1 _provider;
        [TestInitialize]
        public void Setup()
        {
            _provider = new Service1();
            Model1Container container = new Model1Container();
            AccountsSet accounts = new AccountsSet();
            container
        }
        [TestMethod]
        public void TestLoginWithValidUser()
        {
        }
    }
}
