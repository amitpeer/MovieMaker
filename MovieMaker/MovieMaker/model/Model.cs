using MovieMaker.controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using MathNet;
//using MathNet.Numerics.LinearAlgebra;
//using MathNet.Numerics.LinearAlgebra.Double;

namespace MovieMaker.model
{
    public class Model : IModel
    {
        string local_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));


        private IController _controller;
        private Dictionary<string,int> selectedMovieNamesID = new Dictionary<string, int>();
        private Dictionary<int, Dictionary<int,double>> CommonMoviesRating = new Dictionary<int, Dictionary<int, double>>();
        private Dictionary<int,double> otherUsersAverageRating = new Dictionary<int, double>();
        List<MovieRating> MovieRatingList;
        List<Movie> MoviesList;
        double userAvgRating;
        Dictionary<int, string> reversedDictoinary;
        Dictionary<int, List<MovieRating>> findListRatingByMovieID = new Dictionary<int, List<MovieRating>>();
        Dictionary<int, string> movieName = new Dictionary<int, string>();

        public Model()
        {                   
            selectedMovieNamesID.Add("Ace Ventura: When Nature Calls (1995)", 0);
            selectedMovieNamesID.Add("Toy Story (1995)", 0);
            selectedMovieNamesID.Add("Titanic (1997)", 0);
            selectedMovieNamesID.Add("Terminator 2: Judgment Day (1991)", 0);
            selectedMovieNamesID.Add("Scary Movie (2000)", 0);
            selectedMovieNamesID.Add("Lord of the Rings: The Return of the King, The (2003)", 0);
            selectedMovieNamesID.Add("Saving Private Ryan (1998)", 0);
            selectedMovieNamesID.Add("Space Jam (1996)", 0);
            selectedMovieNamesID.Add("Star Wars: Episode V - The Empire Strikes Back (1980)", 0);
            selectedMovieNamesID.Add("Grease (1978)", 0);          
        }

        public void findSelectedMoviesID(Dictionary<string, int> movieNamesID)
        {            
            foreach (var movie in MoviesList)
            {
                if (movieNamesID.Keys.Contains(movie.MovieName))
                {
                    movieNamesID[movie.MovieName] = movie.MovieID;
                }
            }
        }

        public void findCommonMoviesRating()
        {
            foreach (var movieRating in MovieRatingList)
            {
                if (selectedMovieNamesID.Values.Contains(movieRating.MovieID))
                {
                    if (!CommonMoviesRating.Keys.Contains(movieRating.UserID))
                    {
                        CommonMoviesRating[movieRating.UserID] = new Dictionary<int, double>();
                        CommonMoviesRating[movieRating.UserID].Add(movieRating.MovieID, movieRating.UserRating);
                    }
                    else
                    {
                        CommonMoviesRating[movieRating.UserID].Add(movieRating.MovieID, movieRating.UserRating);
                    }

                }              
            }
        }

        public void findListRatingByMovieID1()
        {
            foreach (var movieRating in MovieRatingList)
            {
                if (CommonMoviesRating.Keys.Contains(movieRating.UserID))
                {
                    if (!findListRatingByMovieID.Keys.Contains(movieRating.MovieID))
                    {
                        findListRatingByMovieID[movieRating.MovieID] = new List<MovieRating>();
                    }
                    else
                    {
                        findListRatingByMovieID[movieRating.MovieID].Add(movieRating);

                    }
                }
            }
            var a = findListRatingByMovieID[362];
        }

        public Dictionary<int,string> reverseDictionary()
        {
            Dictionary<int, string> reversed = new Dictionary<int, string>();
            foreach (var item in selectedMovieNamesID)
            {
                reversed[item.Value] = item.Key;
            }
            return reversed;
        }

        public Dictionary<string, double> findP(Dictionary<int, double> W)
        {

            findListRatingByMovieID1();
            Dictionary<string, double> result = new Dictionary<string, double>();
            double sumW = 0;
            foreach (int movieId in findListRatingByMovieID.Keys)
            {
                double Numerator = 0;
                for (int i = 0; i < findListRatingByMovieID[movieId].Count; i++)
                {

                    Numerator += ((findListRatingByMovieID[movieId][i].UserRating) - (otherUsersAverageRating[findListRatingByMovieID[movieId][i].UserID])) * W[findListRatingByMovieID[movieId][i].UserID];
                     sumW += W[findListRatingByMovieID[movieId][i].UserID];
                }

                double p = userAvgRating + (Numerator / sumW);
                if(result.Keys.Contains(movieName[movieId]))
                {
                    continue;
                }
                var a = movieName[movieId];
                result.Add(movieName[movieId], p);
            }
            return result;
        }


        public double findSum(Dictionary<int, double> W)
        {
            double sum = 0;
            foreach (double w in W.Values)
            {
                sum += w;
            }
            return sum;
        }


        public void findUserAvg(Dictionary<string, double> ranksVector)
        {
            double avg = 0;
            foreach (double rate in ranksVector.Values)
            {
                avg += rate;
            }
            userAvgRating = avg / (ranksVector.Values.Count);
        }

        public void calculateUserAverageRating()
        {
            
            Dictionary<int, int> countRatingsToUser = new Dictionary<int, int>();
            foreach(var movieRating in MovieRatingList)
            {
                if(!otherUsersAverageRating.ContainsKey(movieRating.UserID))
                {
                    otherUsersAverageRating[movieRating.UserID] = movieRating.UserRating;
                    countRatingsToUser[movieRating.UserID] = 1;
                }
                else
                {
                    otherUsersAverageRating[movieRating.UserID] += movieRating.UserRating;
                    countRatingsToUser[movieRating.UserID]++;
                }
            }
            var userList = otherUsersAverageRating.Keys.ToList();
            for (int i = 0; i < otherUsersAverageRating.Count; i++)
            {
                otherUsersAverageRating[userList[i]] = otherUsersAverageRating[userList[i]] / countRatingsToUser[userList[i]];
            }
        }

        private Dictionary<int,double> pearsonCorreleationWeight(Dictionary<string, double> ranksVector)
        {
            Dictionary<int, double> usersWeights = new Dictionary<int, double>();
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            //first calculation            
            foreach(var user in CommonMoviesRating.Keys)
            {
                foreach(var movieRating in CommonMoviesRating[user])
                {
                    sum1 +=(ranksVector[reversedDictoinary[movieRating.Key]]- userAvgRating)*(movieRating.Value - otherUsersAverageRating[user]);
                    sum2 += Math.Pow((ranksVector[reversedDictoinary[movieRating.Key]] - userAvgRating), 2);
                    sum3 += Math.Pow((movieRating.Value - otherUsersAverageRating[user]), 2);                    
                }
                double sum4 = Math.Sqrt(sum2 * sum3);
                double sum5 = sum1 / sum4;
                usersWeights[user] = sum5;

            }
            return usersWeights;
        }
        

        public void setController(IController controller)
        {
            _controller = controller;
        }

        public List<string> recommend(Dictionary<string, double> ranksVector)
        {
            try
            {
                MoviesList = readSCVMovieFile(local_path + "\\model\\dataBase\\movies.csv");
                MovieRatingList = readSCVRatingFile(local_path + "\\model\\dataBase\\ratings.csv");
                findSelectedMoviesID(selectedMovieNamesID);
                reversedDictoinary = reverseDictionary();
                Dictionary<string, double> recommend = new Dictionary<string, double>();
                findCommonMoviesRating();
                findUserAvg(ranksVector);
                calculateUserAverageRating();
                recommend = findP(pearsonCorreleationWeight(ranksVector));
                List<KeyValuePair<string, double>> top5 = recommend.OrderByDescending(pair => pair.Value).Take(5).ToList();
                List<string> allKeys = (from kvp in top5 select kvp.Key).ToList();
                return allKeys;
            }
            catch (Exception e)
            {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("recommendError");
                return errorMessage;
            }
        }

        //reading methods
        public List<MovieRating> readSCVRatingFile(string path)
        {
            using (var fs = File.OpenRead(path))
            using (var reader = new StreamReader(fs))
            {
                reader.ReadLine();
                List<MovieRating> ratings = new List<MovieRating>();                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    ratings.Add(new MovieRating(Int32.Parse(values[0]) , Int32.Parse(values[1]), Double.Parse(values[2])));
                }
            return ratings;
            }
        }
        public List<Movie> readSCVMovieFile(string path)
        {
            using (var fs = File.OpenRead(path))
            using (var reader = new StreamReader(fs))
            {
                reader.ReadLine();
                List<Movie> movies = new List<Movie>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(line.Contains("\""))
                    {
                        var split = line.Split('\"');
                        var id = split[0].Split(',');
                        //var genres = split[2].Split(',')[1].Split('|').ToList();
                        movies.Add(new Movie(split[1], Int32.Parse(id[0]), null));
                        movieName.Add(Int32.Parse(id[0]), split[1]);
                    }
                    else
                    {
                    var values = line.Split(',');
                    List<string> genres = new List<string>(values[2].Split('|'));
                    movies.Add(new Movie(values[1], Int32.Parse(values[0]), null));
                    movieName.Add(Int32.Parse(values[0]), values[1]);

                    }

                }
                return movies;
            }
        }

    }
    public class MovieRating
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private int _movieID;

        public int MovieID
        {
            get { return _movieID; }
            set { _movieID = value; }
        }
        private double _userRating;

        public double UserRating
        {
            get { return _userRating; }
            set { _userRating = value; }
        }
        public MovieRating(int userID, int movieID, double userRating)
        {
            UserID = userID;
            MovieID = movieID;
            UserRating = userRating;
        }
    }

    public class Movie
    {
        private string _movieName;

        public string MovieName
        {
            get { return _movieName; }
            set { _movieName = value; }
        }
        private int _movieID;

        public int MovieID
        {
            get { return _movieID; }
            set { _movieID = value; }
        }
        private List<string> genres;

        public List<string> Genres
        {
            get { return genres; }
            set { genres = value; }
        }
        public Movie(string movieName, int movieID, List<string> genres)
        {
            MovieName = movieName;
            MovieID = movieID;
            Genres = genres;
        }
    }
}
