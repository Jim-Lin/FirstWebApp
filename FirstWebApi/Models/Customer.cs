namespace FirstWebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CustName { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public IList<Order> Orders { get; set; }
    }
}