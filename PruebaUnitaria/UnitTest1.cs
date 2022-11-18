using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SistemaDivisasAPI.Controllers;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.DTO;
using SistemaDivisasAPI.Mediator;
using System;

namespace PruebaUnitaria
{
    delegate Type GetTipo();

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<LoginQuery, LoginDTO>()
                );

            var mapper = new Mapper(config);

            var serviceFactory = new ServiceFactory(t => t.FullName);

            var mediator = new Mediator(serviceFactory);

            var clienteController = new ClienteController(mediator, mapper);

            var response = clienteController.Login("CFulanito", "P455w0rD");

            Assert.IsNotNull(response);
        }
    }
}