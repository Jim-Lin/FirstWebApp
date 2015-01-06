namespace FirstAppUnitTest
{
    using System;
    using FirstWebApp;
    using FirstWebApp.Services;
    using Xunit;

    public class UnitTest
    {
        private static FirstEntities entities = new FirstEntities();
        private AppService<Customer> custService = new CustomerService(entities);

        [Fact]
        public void TestCustName()
        {
            Assert.Equal("JimLin", this.custService.GetRecordById(2).CustName);
        }
    }
}
