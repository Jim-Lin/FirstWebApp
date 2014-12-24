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
        private CustomerService appService = new CustomerService();

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
        public void TestAddAndDeleteCustomer()
        {
            this.AddCustomer();
            this.DeleteCustomer();
        }

        private void AddCustomer()
        {
            this.appService.AddCustomer(new Customer { CustName = "TEST" });
            Assert.NotNull(this.appService.GetCustomerByName("TEST"));
        }

        private void DeleteCustomer()
        {
            Customer cust = this.appService.GetCustomerByName("TEST");
            if (cust != null)
            {
                this.appService.DeleteCustomer(cust);
                Assert.Null(this.appService.GetCustomerByName("TEST"));
            }
            else
            {
                Assert.NotNull(cust);
            }
        }
    }
}