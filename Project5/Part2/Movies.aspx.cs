using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Text;

namespace Part2
{
    public partial class Movies : System.Web.UI.Page
    {
        Movie searchResults;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string title = searchTextBox.Text;
            string url = "http://omdbapi.com/?t=" + title + "&r=json&tomatoes=true";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string jsonResponse = reader.ReadToEnd();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Movie));
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonResponse));
            searchResults = (Movie)js.ReadObject(mStream);

            WriteMovies();
        }

        protected void WriteMovies()
        {
            Response.Write("<table>");
            Response.Write("<tr><td> Title: " + searchResults.Title + "</td></tr>");
            Response.Write("<tr><td> Runtime: " + searchResults.Runtime + "</td></tr>");
            Response.Write("<tr><td> Genre: " + searchResults.Genre + "</td></tr>");
            Response.Write("<tr><td> Plot: " + searchResults.Plot + "</td></tr>");
            Response.Write("<tr><td> Tomato Rating: " + searchResults.tomatoRating + "</td></tr>");
            Response.Write("<tr><td> Fresh: " + searchResults.tomatoFresh + "</td></tr>");
            Response.Write("<tr><td> Rotten: " + searchResults.tomatoRotten + "</td></tr>");
            Response.Write("</table>");
        }

        [DataContract]
        public class Movie
        {
            [DataMember]
            public string Title { get; set; }
            [DataMember]
            public string Genre { get; set; }
            [DataMember]
            public string Plot { get; set; }
            [DataMember]
            public string Released { get; set; }
            [DataMember]
            public string tomatoRating { get; set; }
            [DataMember]
            public string Runtime { get; set; }
            [DataMember]
            public string tomatoFresh { get; set; }
            [DataMember]
            public string tomatoRotten { get; set; }
        }
    }
}