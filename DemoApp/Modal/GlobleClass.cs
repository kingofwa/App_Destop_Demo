using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Modal
{
    public class TokenResponse
    {
        public TokenData Data { get; set; }
        public bool Success { get; set; }
        public object Errors { get; set; }
    }

    public class TokenData
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
