using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieMaker.view
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        private List<string> suggestedMovies = new List<string>();
        private List<List<string>> movieDetails = new List<List<string>>();

        public Results(List<string> moviesToSuggest)
        {
            InitializeComponent();
            this.suggestedMovies = moviesToSuggest;
            Title.FontSize = 20;
            Title.Inlines.Add(new Bold(new Run("Best rate:")));
            getMoviesDetails();
            showResults();
        }

        private void getMoviesDetails()
        {
            suggestedMovies.ForEach(movie => movieDetails.Add(getMovieDetails(movie)));
        }
        
        //return movie details, 
        //first is the name ,seconed is year, thirs is plot , fourth is movie poster , five index is actors.
        private List<string> getMovieDetails(string movie)
        {
            List<string> movieDetails = new List<string>();
            string posterUrl = "";
            string year = "";
            string plot = "";
            string actor = "";
            string title = "";
            string requestUrl = "http://www.omdbapi.com/?t=" + movie;
            WebRequest request = WebRequest.Create(requestUrl);
            request.ContentType = "application/json; charset=utf-8";
            WebResponse response = null;
            try
            {
                response = request.GetResponse();

            }
            catch (Exception)
            {
                movieDetails.Add(movie);
                for (int i = 0; i < 5; i++)
                    movieDetails.Add("Data not found");
                return movieDetails;
            }
            string text = "";
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            try
            {
                title = text.Split(',').Where(s => s.Contains("Title"))
                                           .FirstOrDefault()
                                           .Substring(9);
                posterUrl = text.Split(',').Where(s => s.Contains("Poster"))
                                           .FirstOrDefault()
                                           .Substring(10);
                year = text.Split(',').Where(s => s.Contains("Year"))
                                           .FirstOrDefault()
                                           .Substring(8);
                actor = text.Split(',').Where(s => s.Contains("Actors"))
                                           .FirstOrDefault()
                                           .Substring(10);

                //plot is special case.
                string[] plotSplit = text.Split((new string[] { "Plot", "Language" }), StringSplitOptions.None);
                plot = plotSplit[1].Substring(3);
                movieDetails.Add(title.Substring(1, title.Length - 2));
                movieDetails.Add(year.Substring(0, year.Length - 1));
                movieDetails.Add(plot.Substring(0, plot.Length - 3));
                movieDetails.Add(posterUrl.Substring(0, posterUrl.Length - 1));
                movieDetails.Add(actor.Substring(0, actor.Length));

                

            }
            catch (Exception e)
            {
                for(int i=0;i<5;i++)
                    movieDetails.Add("Data not found");
            }

            return movieDetails;
        }

        private void showResults()
        {
            setImageSource();
            locateText();
        }

        private void locateText()
        {
          //titles and year
            title_1.Inlines.Add(new Bold(new Run(movieDetails[0][0]+"  ("+movieDetails[0][1]+")")));
            title_2.Inlines.Add(new Bold(new Run(movieDetails[1][0] + "  (" + movieDetails[1][1] + ")")));
            title_3.Inlines.Add(new Bold(new Run(movieDetails[2][0] + "  (" + movieDetails[2][1] + ")")));
            title_4.Inlines.Add(new Bold(new Run(movieDetails[3][0] + "  (" + movieDetails[3][1] + ")")));
            title_5.Inlines.Add(new Bold(new Run(movieDetails[4][0] + "  (" + movieDetails[4][1] + ")")));

            //plot and man actor
            text_1.Inlines.Add(movieDetails[0][2]);
            text_1.Inlines.Add(new Bold(new Run("\nMain Actor: " + movieDetails[0][4])));
            text_2.Inlines.Add(movieDetails[1][2]);
            text_2.Inlines.Add(new Bold(new Run("\nMain Actor: " + movieDetails[1][4])));
            text_3.Inlines.Add(movieDetails[2][2]);
            text_3.Inlines.Add(new Bold(new Run("\nMain Actor: " + movieDetails[2][4])));
            text_4.Inlines.Add(movieDetails[3][2]);
            text_4.Inlines.Add(new Bold(new Run("\nMain Actor: " + movieDetails[3][4])));
            text_5.Inlines.Add(movieDetails[4][2]);
            text_5.Inlines.Add(new Bold(new Run("\nMain Actor: " + movieDetails[4][4])));
        }

        private void setImageSource()
        {
            setImageElement(movie_1,0);
            setImageElement(movie_2, 1);
            setImageElement(movie_3, 2);
            setImageElement(movie_4, 3);
            setImageElement(movie_5, 4);

        }

        private void setImageElement(Image movie,int index)
        {
            try
            {
                movie.Source = new BitmapImage(
                                 new Uri(movieDetails[index][3], UriKind.Absolute));
            }
            catch (Exception)
            {
                
            }
        }
    }
}
