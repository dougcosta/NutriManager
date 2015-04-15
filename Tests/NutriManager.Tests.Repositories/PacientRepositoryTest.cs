using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutriManager.Repositories;
using NutriManager.Entities;
using Moq;
using NutriManager.Interfaces.Repositories;
using System.Data.Entity;
using NutriManager.Data;
using NutriManager.Data.Interfaces;

namespace NutriManager.Tests.Repositories
{
    [TestClass]
    public class PacientRepositoryTest
    {
        [TestMethod]
        public void Should_save_item()
        {
            var pacient = new Pacient();

            var recipeMock = new Mock<DbSet<Pacient>>();
            var contextMock = new Mock<DataContext>();
            contextMock
                .Setup(s => s.Pacients)
                .Returns(recipeMock.Object);

            var dataFactoryMock = new Mock<IDataFactory>();
            dataFactoryMock
                .Setup(s => s.Get())
                .Returns(contextMock.Object);

            var repository = new PacientRepository(dataFactoryMock.Object);
            repository.Save(pacient);

            contextMock.Verify(v => v.SaveChanges(), Times.Once(),
                "Pacient not saved.");
        }

        [TestMethod]
        public void Should_save_the_right_item()
        {
            var pacient = new Pacient();

            var recipeMock = new Mock<DbSet<Pacient>>();
            var contextMock = new Mock<DataContext>();
            contextMock
                .Setup(s => s.Pacients)
                .Returns(recipeMock.Object);

            var dataFactoryMock = new Mock<IDataFactory>();
            dataFactoryMock
                .Setup(s => s.Get())
                .Returns(contextMock.Object);

            var repository = new PacientRepository(dataFactoryMock.Object);
            repository.Save(pacient);

            recipeMock.Verify(v => v.Add(pacient), Times.Once(),
                "Pacient not saved the right item.");
        }

        [TestMethod]
        public void Should_generate_pacient_id()
        {
            var pacient = new Pacient();

            var recipeMock = new Mock<DbSet<Pacient>>();
            var contextMock = new Mock<DataContext>();
            contextMock
                .Setup(s => s.Pacients)
                .Returns(recipeMock.Object);

            var dataFactoryMock = new Mock<IDataFactory>();
            dataFactoryMock
                .Setup(s => s.Get())
                .Returns(contextMock.Object);

            var repository = new PacientRepository(dataFactoryMock.Object);
            repository.Save(pacient);

            recipeMock.Verify(v => 
                v.Add(It.Is<Pacient>(
                    i => !i.Id.Equals(Guid.Empty))), 
                Times.Once(),
                "Pacient id was not generated.");
        }

        [TestMethod]
        public void Should_not_generate_pacient_id_when_is_not_a_new_pacient()
        {
            var expectedId = Guid.NewGuid();
            var pacient = new Pacient();
            pacient.Id = expectedId;

            var recipeMock = new Mock<DbSet<Pacient>>();
            var contextMock = new Mock<DataContext>();
            contextMock
                .Setup(s => s.Pacients)
                .Returns(recipeMock.Object);

            var dataFactoryMock = new Mock<IDataFactory>();
            dataFactoryMock
                .Setup(s => s.Get())
                .Returns(contextMock.Object);

            var repository = new PacientRepository(dataFactoryMock.Object);
            repository.Save(pacient);

            recipeMock.Verify(v =>
                v.Add(It.Is<Pacient>(
                    i => i.Id.Equals(expectedId))),
                Times.Once(),
                "Pacient id was not generated.");
        }
    }
}
