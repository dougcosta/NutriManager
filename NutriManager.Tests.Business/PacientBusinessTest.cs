using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutriManager.Entities;
using Moq;
using NutriManager.Interfaces.Business;
using NutriManager.Business;
using NutriManager.Interfaces.Repositories;

namespace NutriManager.Tests.Business
{
    [TestClass]
    public class PacientBusinessTest
    {
        [TestMethod]
        public void Should_save_pacient()
        {
            var pacient = new Pacient();

            var repositoryMock = new Mock<IRepository<Pacient>>();
            var repositoryFactoryMock = new Mock<IRepositoryFactory>();
            repositoryFactoryMock
                .Setup(s => s.Get<Pacient>())
                .Returns(repositoryMock.Object);

            var business = new PacientBusiness(repositoryFactoryMock.Object);
            business.Save(pacient);

            repositoryMock.Verify(v => v.Save(pacient), Times.Once(),
                "Pacient not saved.");
        }
    }
}
