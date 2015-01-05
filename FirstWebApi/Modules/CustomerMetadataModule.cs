namespace FirstWebApi.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using FirstWebApi.Models;
    using Nancy.Metadata.Module;
    using Nancy.Swagger;

    public class CustomerMetadataModule : MetadataModule<SwaggerRouteData>
    {
        public CustomerMetadataModule()
        {
            this.Describe["GetCustomers"] = description => description.AsSwagger(with =>
            {
                with.ResourcePath("/customer");
                with.Summary("The list of customers");
                with.Notes("This returns a list of customers");
                with.Model<Customer>();
            });
        }
    }
}