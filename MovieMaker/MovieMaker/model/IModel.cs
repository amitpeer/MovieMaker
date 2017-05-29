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

        List<string> addRanks(Dictionary<string, double> newRanksVector);

        double moviePredictedRank(string movie);

        void calculateUserAverageRating();
    }
}
