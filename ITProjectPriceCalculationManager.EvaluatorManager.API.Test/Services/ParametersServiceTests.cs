using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.EvaluateParameter;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.ParameterValue;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Test.Services;

[TestFixture]
public class ParametersServiceTests
{
    private Mock<IRepository<Parameters, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>> _repositoryMock;
    private Mock<IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>> _evaluateParameterRepositoryMock;
    private Mock<IRepository<ParameterValue, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>> _parameterValueRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private ParametersService _service;
    private ParametersDTO _dto;
    private Parameters _entity;
    private Guid _id;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IRepository<Parameters, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>>();
        _repositoryMock.Setup(r => r.SaveChangesAcync()).ReturnsAsync(1);
        _evaluateParameterRepositoryMock = new Mock<IRepository<EvaluateParameter, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>>();
        _parameterValueRepositoryMock = new Mock<IRepository<ParameterValue, Guid, ITProjectPriceCalculationEvaluatorManagerDbContext>>();
        _mapperMock = new Mock<IMapper>();
        _service = new ParametersService(
            _evaluateParameterRepositoryMock.Object,
            _parameterValueRepositoryMock.Object,
            _repositoryMock.Object,
            _mapperMock.Object
        );

        _dto = new ParametersDTO
        {
            Id = Guid.NewGuid(),
            Name = string.Empty
        };

        _entity = new Parameters
        {
            Id = _dto.Id,
            Name = string.Empty
        };

        _id = _dto.Id;

        _mapperMock.Setup(m => m.Map<Parameters>(_dto)).Returns(_entity);
        _mapperMock.Setup(m => m.Map<ParametersDTO>(_entity)).Returns(_dto);
    }

    [Test]
    public async Task CreateParametersAsync_Should_Create_Parameters()
    {
        // Arrange
        _repositoryMock.Setup(r => r.AddAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.CreateParametersAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.AddAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task DeleteParametersAsync_Should_Delete_Parameters()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);
        _repositoryMock.Setup(r => r.DeleteAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.DeleteParametersAsync(_id);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
        _repositoryMock.Verify(r => r.DeleteAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task GetParametersAsync_Should_Return_All_Parameters()
    {
        // Arrange
        var entities = new List<Parameters> { _entity };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mapperMock.Setup(m => m.Map<IEnumerable<ParametersDTO>>(entities)).Returns(new List<ParametersDTO>());

        // Act
        var result = await _service.GetParametersAsync();

        // Assert
        Assert.IsNotNull(result);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    [Test]
    public async Task GetParameterssByIdAsync_Should_Return_Parameters_By_Id()
    {
        // Arrange
        _repositoryMock.Setup(r => r.GetByKeyAsync(_id)).ReturnsAsync(_entity);

        // Act
        var result = await _service.GetParameterssByIdAsync(_id);

        // Assert
        Assert.IsNotNull(result);
        _repositoryMock.Verify(r => r.GetByKeyAsync(_id), Times.Once);
    }

    [Test]
    public async Task UpdateParametersAsync_Should_Update_Parameters()
    {
        // Arrange
        _repositoryMock.Setup(r => r.UpdateAsync(_entity)).ReturnsAsync(_entity);

        // Act
        var result = await _service.UpdateParametersAsync(_dto);

        // Assert
        Assert.That(result, Is.EqualTo(_dto));
        _repositoryMock.Verify(r => r.UpdateAsync(_entity), Times.Once);
        _repositoryMock.Verify(r => r.SaveChangesAcync(), Times.Once);
    }

    [Test]
    public async Task GetParametersByApplicationIdAsync_Should_Return_Parameters_By_ApplicationId()
    {
        // Arrange
        var applicationId1 = Guid.NewGuid();
        var applicationId2 = Guid.NewGuid();
        var parameterId1 = Guid.NewGuid();
        var parameterId2 = Guid.NewGuid();
        var evaluateParameterId = Guid.NewGuid();
        var parameterValueId = Guid.NewGuid();

        var parametersList = new List<Parameters>
        {
            new Parameters { Id = parameterId1, Name = string.Empty, ApplicationId = applicationId1 },
            new Parameters { Id = parameterId2, Name = string.Empty, ApplicationId = applicationId2 }
        };

        var evaluateParametersList = new List<EvaluateParameter>
        {
            new EvaluateParameter { Id = evaluateParameterId, Name = string.Empty, ParameterId = parameterId1 }
        };

        var parameterValuesList = new List<ParameterValue>
        {
            new ParameterValue { Id = evaluateParameterId }
        };

        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(parametersList);
        _evaluateParameterRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(evaluateParametersList);
        _parameterValueRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(parameterValuesList);
        _mapperMock.Setup(m => m.Map<IEnumerable<ParametersDTO>>(It.IsAny<IEnumerable<Parameters>>())).Returns(new List<ParametersDTO>());

        // Act
        var result = await _service.GetParametersByApplicationIdAsync(applicationId1);

        // Assert
        Assert.IsNotNull(result);
        _repositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        _evaluateParameterRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
        _parameterValueRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }
}