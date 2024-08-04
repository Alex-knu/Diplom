using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Test.Services;

[TestFixture]
public class EvaluateParameterServiceTests
{
    private Mock<IParameterValueService> _parameterValueServiceMock;
    private Mock<IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>> _repositoryMock;
    private Mock<IMapper> _mapperMock;
    private EvaluateParameterService _service;
    private EvaluateParameterDTO _dto;
    private EvaluateParameter _entity;
    private Guid _id;

    [SetUp]
    public void Setup()
    {
        _parameterValueServiceMock = new Mock<IParameterValueService>();
        _repositoryMock = new Mock<IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>>();
        _mapperMock = new Mock<IMapper>();
        _service = new EvaluateParameterService(
            _parameterValueServiceMock.Object,
            _repositoryMock.Object,
            _mapperMock.Object
        );

        _dto = new EvaluateParameterDTO
        {
            Id = Guid.NewGuid(),
            Name = string.Empty,
            EvaluateParameterValue = new ParameterValueDTO { Id = Guid.NewGuid() }
        };

        _entity = new EvaluateParameter
        {
            Id = _dto.Id,
            Name = string.Empty,
            EvaluateParameterValue = new ParameterValue { Id = _dto.EvaluateParameterValue.Id }
        };

        _id = _dto.Id;

        _mapperMock.Setup(m => m.Map<EvaluateParameter>(_dto)).Returns(_entity);
        _mapperMock.Setup(m => m.Map<EvaluateParameterDTO>(_entity)).Returns(_dto);
        _repositoryMock.Setup(r => r.SaveChangesAcync()).Returns(Task.FromResult(1));
    }

    [Test]
    public async Task CreateEvaluateParameterAsync_Should_Create_EvaluateParameter()
    {
        // Arrange
        _repositoryMock.Setup(r => r.AddAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.CreateEvaluateParameterAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.AddAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task DeleteEvaluateParameterAsync_Should_Delete_EvaluateParameter()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);
        _repositoryMock.Setup(r => r.DeleteAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.DeleteEvaluateParameterAsync(_id);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
        _repositoryMock.Verify(r => r.DeleteAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task GetEvaluateParametersByParameterIdAsync_Should_Return_EvaluateParameters_By_ParameterId()
    {
        // Arrange
        var parameterId = Guid.NewGuid();
        var entities = new List<EvaluateParameter>
        {
            new EvaluateParameter { ParameterId = parameterId, Name = string.Empty },
            new EvaluateParameter { ParameterId = parameterId, Name = string.Empty }
        };

        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mapperMock.Setup(m => m.Map<IEnumerable<EvaluateParameterDTO>>(entities)).Returns(new List<EvaluateParameterDTO>());

        // Act
        var result = await _service.GetEvaluateParametersByParameterIdAsync(parameterId);

        // Assert
        Assert.IsNotNull(result);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task GetEvaluateParameterAsync_Should_Return_All_EvaluateParameters()
    {
        // Arrange
        var entities = new List<EvaluateParameter> { _entity };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);

        // Act
        var result = await _service.GetEvaluateParameterAsync();

        // Assert
        Assert.IsNotNull(result);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task GetEvaluateParametersByIdAsync_Should_Return_EvaluateParameter_By_Id()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);

        // Act
        var result = await _service.GetEvaluateParametersByIdAsync(_id);

        // Assert
        Assert.IsNotNull(result);
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
    }

    [Test]
    public async Task UpdateEvaluateParameterAsync_Should_Update_EvaluateParameter()
    {
        // Arrange
        _repositoryMock.Setup(r => r.UpdateAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.UpdateEvaluateParameterAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.UpdateAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }
}