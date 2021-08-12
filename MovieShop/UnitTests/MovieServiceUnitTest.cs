using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MovieServiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private MovieService _sut;
        private static List<Movie> _movies;
        private Mock<IMovieRepository> _mockMovieRepository;

        [TestInitialize]
        //[Onetimesetup] in nUnit
        public void OneTimeSetup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
            _mockMovieRepository.Setup(m => m.GetHighest30GrossingMovies()).ReturnsAsync(_movies);
        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _movies = new List<Movie> {
                new Movie { Id=1, Title="Avengers: Infinity War",Budget=1200000 },
                new Movie { Id=2, Title="Avatar",Budget=1200000 }
            };
        }

        [TestMethod]
        public async Task Test_List_Of_Highest_Grossing_Movies_From_Fake_Data()
        {
            //movieservice => gettoprevenewmovies
            var movies = await _sut.GetTopRevenueMovies();
            //check the actual output with expected data
            //arrange.act and assert.

            Assert.IsNotNull(movies);
            Assert.AreEqual(2, movies.Count());
            //can have multiple asserts.
            //But one assert is fail, all tests will fail

        }

    }
}
