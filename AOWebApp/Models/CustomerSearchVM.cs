using AOWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace AOWebApp.Models
{
    public class CustomerSearchVM
    {
        [Required(ErrorMessage = "You must provide a Customer Name")]
        public string SearchText { get; set; }
        public string Suburbt { get; set; }
        public SelectList SuburbList { get; set; }
        public List<Customers> CustomerList { get; set; }
        public List<string> NameList { get; set; }
    }
}
