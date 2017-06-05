using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieMaker;
using MovieMaker.view;
using MovieMaker.controller;
using MovieMaker.model;
using System.Collections.Generic;

namespace MovieMakerTests
{
    [TestClass]
    public class ModelTests
    {
        private IModel model = new Model();
        private Dictionary<string, double> movieNamesToRank = new Dictionary<string, double>();
        private List<string> results = new List<string>();

        [TestMethod]
        public void testRecommendNoRanks()
        {
            string expected = "recommendError";
            results = model.recommend(movieNamesToRank);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expected, results[0]);
        }

        [TestMethod]
        public void testRecommendOneRanks()
        {
            string expected = "recommendError";
            movieNamesToRank.Add("Ace Ventura: When Nature Calls (1995)", 1);
            results = model.recommend(movieNamesToRank);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(expected, results[0]);
        }

        [TestMethod]
        public void testRecommendWithLowestRank()
        {
            string expected = "recommendError";
            addRanks(1);
            results = model.recommend(movieNamesToRank);
            Assert.AreEqual(5, results.Count);
            Assert.AreNotEqual(expected, results[0]);
        }

        [TestMethod]
        public void testRecommendWithHighestRank()
        {
            string expected = "recommendError";
            addRanks(5);
            results = model.recommend(movieNamesToRank);
            Assert.AreEqual(5, results.Count);
            Assert.AreNotEqual(expected, results[0]);
        }

        [TestMethod]
        public void testSystemPresicion()
        {
            model.testBeitzim();
        }

        private void addRanks(double rank)
        {
            movieNamesToRank.Add("Ace Ventura: When Nature Calls (1995)", rank);
            movieNamesToRank.Add("Toy Story (1995)", rank);
            movieNamesToRank.Add("Titanic (1997)", rank);
            movieNamesToRank.Add("Terminator 2: Judgment Day (1991)", rank);
            movieNamesToRank.Add("Scary Movie (2000)", rank);
            movieNamesToRank.Add("Lord of the Rings: The Return of the King, The (2003)", rank);
            movieNamesToRank.Add("Saving Private Ryan (1998)", rank);
            movieNamesToRank.Add("Space Jam (1996)", rank); 
            movieNamesToRank.Add("Star Wars: Episode V - The Empire Strikes Back (1980)", rank);
            movieNamesToRank.Add("Grease (1978)", rank);
        }


    }
}
