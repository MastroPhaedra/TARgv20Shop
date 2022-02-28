using System;
using Targv20Shop.ApplicationServices.Services;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Models.Spaceship;
using Xunit;

namespace Spaceship.Test
{
    public class SpaceshipCreate
    {
        private readonly ISpaceshipService _spaceship;
        public SpaceshipCreate
        (ISpaceshipService spaceship){
            spaceship = _spaceship;
    }
        [Fact]
        public void when_CreateNewSpaceship_ThenWillAddNewData()
        {
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

            var result = _spaceship.Add(spaceship);
            Assert.Empty(result);
        }
    }
}
