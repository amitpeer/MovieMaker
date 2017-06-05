using MovieMaker.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMaker.model
{
    public interface IModel
    {
        void setController(IController controller);

        List<string> recommend(Dictionary<string, double> ranksVector);

        void calculateUserAverageRating();

        double testBeitzim();

        Dictionary<string, double> rank(Dictionary<string, double> ranksVector);

        List<User> cutTo100Users();
    }
}
