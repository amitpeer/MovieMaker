using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMaker.controller
{
    public interface IController
    {
        List<string> recommend(Dictionary<string, double> ranksVector);

        List<string> addRanks(Dictionary<string, double> newRanksVector);

        double moviePredictedRank(string movie);

        void echo(string message);
    }
}
