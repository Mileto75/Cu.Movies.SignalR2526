using Cu_ServicePattern_Movies.Core.Entities;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.Movies.Web.Components.Models
{
    public class NewOrUpdateMovieModel
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CompanyId { get; set; }
        //image
        public List<string> Images { get; set; }
        public IBrowserFile BrowserFile { get; set; }
        //price
        public decimal Price { get; set; }
    }
}
