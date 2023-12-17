using System.ComponentModel;

namespace SupplyScopeMVC.Web.Models
{
    public class Product
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
    }
}
