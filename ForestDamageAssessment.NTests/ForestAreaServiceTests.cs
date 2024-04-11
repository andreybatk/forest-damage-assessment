using AutoFixture;
using ForestDamageAssessment.BL.Services;

namespace ForestDamageAssessment.NTests
{
    public class ForestAreaServiceTests
    {
        private ForestAreaService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new ForestAreaService();
        }

        [Test]
        public void CreateForestArea_ShouldCreateNewForestAreaForBush()
        {
            //arrange
            var fixture = new Fixture();

            var count = fixture.Create<int[]>();
            var breedBush = fixture.Create<string[]>();
            var bushType = fixture.Create<string[]>();
            var region = fixture.Create<string>();
            var year = fixture.Create<string>();
            var isOZU = fixture.Create<bool>();
            var isProtectiveForests = fixture.Create<bool>();
            var isOOPT = fixture.Create<bool>();

            //act
            var result = _service.CreateForestArea(count, breedBush, bushType, region, year, isOZU, isProtectiveForests, isOOPT);

            //assert
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void CreateForestArea_ShouldCreateNewForestAreaForTree()
        {
            //arrange
            var fixture = new Fixture();

            var breed = fixture.Create<string[]>();
            var diameter = fixture.Create<string[]>();
            var h = fixture.Create<string[]>();
            var rankH = fixture.Create<string[]>();
            var region = fixture.Create<string>();
            var year = fixture.Create<string>();
            var isOZU = fixture.Create<bool>();
            var isProtectiveForests = fixture.Create<bool>();
            var isOOPT = fixture.Create<bool>();

            //act
            var result = _service.CreateForestArea(breed, diameter, h, rankH, region, year, isOZU, isProtectiveForests, isOOPT);

            //assert
            Assert.That(result, Is.Not.Null);
        }
    }
}