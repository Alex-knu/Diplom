using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.BelongingFunction;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Test.Services;

[TestFixture]
public class BelongingFunctionServiceTests
{
    private Mock<IRepository<BelongingFunction, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>> _repositoryMock;
    private Mock<IMapper> _mapperMock;
    private BelongingFunctionService _service;
    private BelongingFunctionDTO _dto;
    private BelongingFunction _entity;
    private Guid _id;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<BelongingFunction, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>>();
        _mapperMock = new Mock<IMapper>();  
        _service = new BelongingFunctionService(_repositoryMock.Object, _mapperMock.Object);
        SetupCommonTestData();
    }

    private void SetupCommonTestData()
    {
        _dto = new BelongingFunctionDTO() { Name = string.Empty };
        _entity = new BelongingFunction() { Name = string.Empty };
        _id = Guid.NewGuid();
        _mapperMock.Setup(m => m.Map<BelongingFunction>(_dto)).Returns(_entity);
        _mapperMock.Setup(m => m.Map<BelongingFunctionDTO>(_entity)).Returns(_dto);
        _repositoryMock.Setup(r => r.SaveChangesAcync()).Returns(Task.FromResult(1));
    }

    [Test]
    public async Task CreateBelongingFunctionAsync_Should_Create_BelongingFunction()
    {
        // Arrange
        _repositoryMock.Setup(r => r.AddAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.CreateBelongingFunctionAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.AddAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task DeleteBelongingFunctionAsync_Should_Delete_BelongingFunction()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);
        _repositoryMock.Setup(r => r.DeleteAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.DeleteBelongingFunctionAsync(_id);

        // Assert
        Assert.NotNull(result);
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
        _repositoryMock.Verify(r => r.DeleteAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task GetBelongingFunctionAsync_Should_Return_All_BelongingFunctions()
    {
        // Arrange
        var entities = new List<BelongingFunction> { _entity, new BelongingFunction() { Name = string.Empty } };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mapperMock.Setup(m => m.Map<IEnumerable<BelongingFunctionDTO>>(entities)).Returns(new List<BelongingFunctionDTO>());

        // Act
        var result = await _service.GetBelongingFunctionAsync();

        // Assert
        Assert.NotNull(result);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task UpdateBelongingFunctionAsync_Should_Update_BelongingFunction()
    {
        // Arrange
        _repositoryMock.Setup(r => r.UpdateAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.UpdateBelongingFunctionAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.UpdateAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }
}