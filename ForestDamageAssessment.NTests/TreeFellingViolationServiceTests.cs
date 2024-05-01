using AutoFixture;
using ForestDamageAssessment.BL.Interfaces;
using ForestDamageAssessment.BL.Models;
using ForestDamageAssessment.BL.Services;
using ForestDamageAssessment.DB.Interfaces;
using ForestDamageAssessment.DB.Models;
using Moq;

namespace ForestDamageAssessment.NTests
{
    public class TreeFellingViolationServiceTests
    {
        private Mock<IAssortmentRepository> _assortmentRepository;
        private Mock<ITaxPriceRepository> _taxPriceRepository;
        private Mock<IBreedDiameterModelRepository> _breedDiameterModelRepository;
        private Mock<ISTDRepository> _sTDRepository;
        private Mock<IArticleRepository> _articleRepository;
        private TreeFellingViolationService _service;

        [SetUp]
        public void Setup()
        {
            _taxPriceRepository = new Mock<ITaxPriceRepository>();
            _breedDiameterModelRepository = new Mock<IBreedDiameterModelRepository>();
            _sTDRepository = new Mock<ISTDRepository>();
            _assortmentRepository = new Mock<IAssortmentRepository>();
            _articleRepository = new Mock<IArticleRepository>();
            _service = new TreeFellingViolationService(_assortmentRepository.Object, _taxPriceRepository.Object, _breedDiameterModelRepository.Object, _sTDRepository.Object, _articleRepository.Object);
        }

        [Test]
        public void CalculateAsync_ForestAreaModelListIsNull_ThrowArgumentNullException()
        {
            //arange
            var fixture = new Fixture();
            var forestArea = fixture.Build<ForestArea<ITreeViewModel>>()
                .Without(x => x.ModelList)
                .Create();

            //act
            var exception = Assert.ThrowsAsync<ArgumentNullException>(() => _service.CalculateAsync(forestArea));

            //assert
            Assert.IsNotNull(exception);
        }
        [Test]
        public void CalculateAsync_ForestAreaIsValid()
        {
            //arange
            var fixture = new Fixture();
            var modelList = fixture.Build<List<ITreeViewModel>>().Create();
            var forestArea = fixture.Build<ForestArea<ITreeViewModel>>()
                .With(x => x.ModelList, modelList)
                .Create();

            //act
            var result = _service.CalculateAsync(forestArea);

            //assert
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void CalculateAsyncFromFile_FileModelInvalid_ThrowFileNotFoundException()
        {
            //arange
            var fixture = new Fixture();
            var fileModel = fixture.Build<FileModel>().Create();
            var forestArea = fixture.Build<ForestArea<ITreeViewModel>>()
                .Without(x => x.ModelList)
                .Create();

            //act
            var exception = Assert.ThrowsAsync<FileNotFoundException>(() => _service.CalculateFromFileAsync(fileModel, forestArea));

            //assert
            Assert.IsNotNull(exception);
        }
    }
}