using Microsoft.Extensions.DependencyInjection;
using System;
using Targv20Shop.ApplicationServices.Services;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Models.Spaceship;
using Targv20Shop.Spaceship.Test;
using Xunit;

namespace Spaceship.Test
{
    public class SpaceshipCreate : TestBase
    {
        //private readonly ISpaceshipService _spaceship;
        //public SpaceshipCreate (ISpaceshipService spaceship)
        //{
        //    _spaceship = spaceship;
        //}
        [Fact]
        public void when_CreateNewSpaceship_ThenWillAddNewData()
        {
            var service = Svc<ISpaceshipService>();
            var spaceship = new SpaceshipDto
            {
                Name = "Superman",
                Type = "Corvette",
                Mass = 123,
                Prize = 321,
                Crew = 213,
                ConstructedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            var result = service.Add(spaceship);
            //Assert.Empty(result);
        }
    }
}
