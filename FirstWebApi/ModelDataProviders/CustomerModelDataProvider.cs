namespace FirstWebApi.ModelDataProviders
{
    using FirstWebApi.Models;
    using Nancy.Swagger;
    using Nancy.Swagger.Services;

    public class CustomerModelDataProvider : ISwaggerModelDataProvider
    {
        public SwaggerModelData GetModelData()
        {
            return SwaggerModelData.ForType<Customer>(with =>
            {
                with.Description("A customer of our awesome system!");
                with.Property(x => x.CustName)
                    .Description("The customer's name")
                    .Required(true);
            });
        }
    }
}