namespace FirstWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using NLog;

    public class WebAppService
    {
        private FirstEntities entities;
        private static Logger logger;

        public WebAppService()
        {
            this.entities = new FirstEntities();
            WebAppService.logger = LogManager.GetCurrentClassLogger();
        }

        public FirstEntities Entities
        {
            get
            {
                return this.entities;
            }  
        }

        public Logger Logger
        {
            get
            {
                return WebAppService.logger;
            }
        }
    }
}