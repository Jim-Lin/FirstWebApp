namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FirstWebApp.Modules;
    using Nancy;
    using Nancy.Testing;
    using Xunit;

    public class AppTest
    {
        private AppService appService = new AppService();

        [Fact]
        public void TestCustName()
        {
            Assert.Equal("JimLin", this.appService.GetCustomerById(2).CustName);
        }

        [Fact]
        public void TestOrderCount()
        {
            Assert.Equal(2, this.appService.GetCustomerById(2).Order.Count);
        }

        [Fact]
        public void TestThrowsException()
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(
                /// Customer list count is 4
                () =>
                {
                        IList<Customer> cust = this.appService.FindCustomers();
                        return cust[10].Id;
                });
        }

        // "Views" folder must copy paste to the "bin" folder
        [Fact]
        public void TestRouteExists()
        {
            // Given
            var bootstrapper = new ConfigurableBootstrapper(with =>
                             with.AllDiscoveredModules());
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/customer/2", with => with.HttpRequest());

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void TestAddCustomer()
        {
            this.appService.AddCustomer(new Customer { CustName = "TEST" });
            Customer cust = this.appService.GetCustomerByName("TEST");

            Assert.Equal(true, cust != null);
        }

        [Fact]
        public void TestDeleteCustomer()
        {
            Customer cust = this.appService.GetCustomerByName("TEST");
            this.appService.DeleteCustomer(cust);

            Assert.Equal(null, this.appService.GetCustomerByName("TEST"));
        }
    }
}