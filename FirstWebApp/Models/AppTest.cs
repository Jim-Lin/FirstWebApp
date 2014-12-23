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
    }
}