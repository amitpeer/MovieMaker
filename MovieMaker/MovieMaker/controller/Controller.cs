using MovieMaker.model;
using MovieMaker.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMaker.controller
{
    public class Controller : IController
    {
        private IView view;
        private IModel model;

        public Controller(IView view, IModel model)
        {
            this.view = view;
            this.model = model;
        }

        public List<string> recommend(Dictionary<string, double> ranksVector)
        {
            return model.recommend(ranksVector);
        }

        public void echo(string message)
        {
            view.echo(message);
        }
    }
}
