using DemoCore.Domain.Interfaces;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.Repositories;
using System;
using System.Linq;
using Xunit;

namespace DemoCore.Tests.XUnitTestProject.Repositories
{
    public class DeveloperRepositoryUT: BaseTest
    {
        public DeveloperRepositoryUT() : base()
        {
            developerRepository = (DeveloperRepository)GetServiceProvider().GetService(typeof(IDeveloperRepository));

        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2, 2, 4)]
        public void Sum(int i, int d, int sum)
        {
            //Arrange
            //var mock = new Mock<IDeveloperRepository>();

            //var dev = new Developer()
            //{
            //    Id = 1,
            //    DescriptionEN = "Ionic",
            //    DescriptionPT = "Ionic",
            //    EntityState = Domain.Core.Enums.EntityStateEnum.EntityStateOptions.Active
            //};

            //mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(dev);

            ////Act
            //var expDev = mock.Object.GetById(id);





            //Arrange

            //Act
            int result = i + d;

            //Assert
            Assert.Equal(result, sum);
            Assert.True(result == sum);
        }

        [Fact]
        public void Add()
        {
            //Arrange
            var dev = new Developer()
            {
                Id = 0,
                DescriptionEN = "UnitTestEN",
                DescriptionPT = "UnitTestPT",
                EntityState = Domain.Core.Enums.EntityStateEnum.EntityStateOptions.Active,
                DateCreated = DateTime.Now,
                DateLastUpdate = null
            };

            //Act
            developerRepository.Add(dev);
            developerRepository.SaveChanges();
            
            //Assert
            var dbDev = developerRepository.Get(x => x.DescriptionEN.Equals("UnitTestEN")).FirstOrDefault();
            Assert.True(dbDev != null);
            

            
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetById(int id)
        {
            //Arrange
            
            ////Act
            var dbDev = developerRepository.GetById(id);

            //Assert
            Assert.Equal(id, dbDev.Id);
        }

        [Fact]
        public void Update()
        {

        }

        [Fact]
        public void Remove()
        {

        }

    }
}
