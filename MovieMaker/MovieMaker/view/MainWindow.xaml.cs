using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieMaker.view;
using MovieMaker.controller;
using MovieMaker.model;
using System.Net;
using System.IO;

namespace MovieMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        private IController controller;
        private IModel model;
        private Dictionary<string, double> ranks = new Dictionary<string, double>();
        private List<string> movieNamesToRank = new List<string>();
        private List<string> suggestedMovies = new List<string>();
        private List<Label> labelsList;
        private List<ComboBox> combosList;

        public MainWindow()
        {
            InitializeComponent();
            model = new Model();
            controller = new Controller(this, model);
            model.setController(controller);

            initializeLabelsAndCombosLists();

            setMovieNames();

            setMovieLabelsAndComboboxes();         
        }

        private void button_submit_Click(object sender, RoutedEventArgs e)
        {
            if (ranks.Count == 0)
            {
                MessageBox.Show("Please rate at least one movie");
            }
            else
            {
                suggestedMovies = controller.recommend(ranks);
                suggestedMoviesFixFormat(suggestedMovies);
                Results results = new Results(suggestedMovies);
                results.ShowDialog();
            }
            //testResults();
        }

        private void suggestedMoviesFixFormat(List<string> suggestedMovies)
        {
          
            for(int i=0; i<suggestedMovies.Count; i++)
            {
                string myFormat = suggestedMovies[i];
                if(myFormat.Contains(','))
                {
                    myFormat = myFormat.Split(',')[0];
                }
                if (myFormat.Contains('('))
                {
                    myFormat = myFormat.Split('(')[0];
                }
                suggestedMovies[i] = myFormat;
            }
        }
    

        private void combo_rank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string movie = (string)cmb.Tag;
            double selectedValue = (double)cmb.SelectedIndex;

            if (selectedValue != 0)
            {
                ranks[movie] = selectedValue;
            }
        }

        private void setMovieNames()
        {
            movieNamesToRank.Add("Ace Ventura: When Nature Calls (1995)");
            movieNamesToRank.Add("Toy Story (1995)");
            movieNamesToRank.Add("Titanic (1997)");
            movieNamesToRank.Add("Terminator 2: Judgment Day (1991)");
            movieNamesToRank.Add("Scary Movie (2000)");
            movieNamesToRank.Add("Lord of the Rings: The Return of the King, The (2003)");
            movieNamesToRank.Add("Saving Private Ryan (1998)");
            movieNamesToRank.Add("Space Jam (1996)");
            movieNamesToRank.Add("Star Wars: Episode V - The Empire Strikes Back (1980)");
            movieNamesToRank.Add("Grease (1978)");
        }

        private void setMovieLabelsAndComboboxes()
        {
            for (int i = 0; i < movieNamesToRank.Count; i++)
            {
                labelsList[i].Content = movieNamesToRank[i];
                combosList[i].Tag = movieNamesToRank[i];
            }
        }

        private void initializeLabelsAndCombosLists()
        {
            labelsList = new List<Label>() { movie_1, movie_2, movie_3, movie_4, movie_5,
                                            movie_6, movie_7, movie_8, movie_9, movie_10 };

            combosList = new List<ComboBox>() { combo_rank_1, combo_rank_2, combo_rank_3,
                                            combo_rank_4, combo_rank_5, combo_rank_6,
                                            combo_rank_7, combo_rank_8, combo_rank_9,
                                            combo_rank_10};
        }

        public void echo(string message)
        {
            MessageBox.Show(message);
        }


        //testing before model is ready
        public void testResults()
        {
            List<string> testing = new List<string>();
            testing.Add("Titanic");
            testing.Add("Terminator 2: Judgment Day");
            testing.Add("Lord of the Rings: The Return of the King");
            testing.Add("Saving Private Ryan");
            testing.Add("Space Jam");

            Results results = new Results(testing);
            results.ShowDialog();
        }
    }
}
