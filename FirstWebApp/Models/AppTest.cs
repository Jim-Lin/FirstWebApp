namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Xunit;

    public class AppTest
    {
        private WebAppService webAppService = new WebAppService();

        [Fact]
        public void TestCustName()
        {
            Assert.Equal("JimLin", this.webAppService.Entities.Customer.ToArray<Customer>()[0].CustName);
        }

        [Fact]
        public void TestOrderCount()
        {
            Assert.Equal(2, this.webAppService.Entities.Customer.ToArray<Customer>()[0].Order.Count);
        }

        [Fact]
        public void TestThrowsException()
        {
            Assert.Throws<System.IndexOutOfRangeException>(
                /// Customer array length is 4
                () => this.webAppService.Entities.Customer.ToArray<Customer>()[10]);
        }
    }
}