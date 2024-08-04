using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Test.Services;

[TestFixture]
public class ParameterValueServiceTests
{
    private Mock<IRepository<ParameterValue, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>> _repositoryMock;
    private Mock<IMapper> _mapperMock;
    private ParameterValueService _service;
    private ParameterValueDTO _dto;
    private ParameterValue _entity;
    private Guid _id;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<ParameterValue, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>>();
        _mapperMock = new Mock<IMapper>();
        _service = new ParameterValueService(_repositoryMock.Object, _mapperMock.Object);
        SetupCommonTestData();
    }

    private void SetupCommonTestData()
    {
        _dto = new ParameterValueDTO();
        _entity = new ParameterValue();
        _id = Guid.NewGuid();
        _mapperMock.Setup(m => m.Map<ParameterValue>(_dto)).Returns(_entity);
        _mapperMock.Setup(m => m.Map<ParameterValueDTO>(_entity)).Returns(_dto);
        _repositoryMock.Setup(r => r.SaveChangesAcync()).Returns(Task.FromResult(1));
    }

    [Test]
    public async Task CreateParameterValueAsync_Should_Create_ParameterValue()
    {
        // Arrange
        _repositoryMock.Setup(r => r.AddAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.CreateParameterValueAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.AddAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task DeleteParameterValueAsync_Should_Delete_ParameterValue()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);
        _repositoryMock.Setup(r => r.DeleteAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.DeleteParameterValueAsync(_id);

        // Assert
        Assert.NotNull(result);
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
        _repositoryMock.Verify(r => r.DeleteAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task GetParameterValueByIdAsync_Should_Return_ParameterValueDTO()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);

        // Act
        var result = await _service.GetParameterValueByIdAsync(_id);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
    }

    [Test]
    public async Task GetParameterValueAsync_Should_Return_All_ParameterValues()
    {
        // Arrange
        var entities = new List<ParameterValue> { _entity, new ParameterValue() };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mapperMock.Setup(m => m.Map<IEnumerable<ParameterValueDTO>>(entities)).Returns(new List<ParameterValueDTO> { _dto });

        // Act
        var result = await _service.GetParameterValueAsync();

        // Assert
        Assert.NotNull(result);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task UpdateParameterValueAsync_Should_Update_ParameterValue()
    {
        // Arrange
        _repositoryMock.Setup(r => r.UpdateAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.UpdateParameterValueAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.UpdateAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }
}
