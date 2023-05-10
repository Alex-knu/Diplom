using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class EvaluatorService : IEvaluatorService
    {
        protected readonly IRepository<Estimator, int> _estimatorRepository;
        protected readonly IMapper _mapper;

        public EvaluatorService(IRepository<Estimator, int> estimatorRepository, IMapper mapper)
        {
            _estimatorRepository = estimatorRepository;
            _mapper = mapper;
        }

        public async Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            var domainEvaluator = _mapper.Map<Estimator>(evaluator);

            var newEvaluator = await _estimatorRepository.AddAsync(domainEvaluator);
            await _estimatorRepository.SaveChangesAcync();

            return _mapper.Map<EvaluatorDTO>(newEvaluator);
        }

        public async Task<EvaluatorDTO> DeleteEvaluatorAsync(int id)
        {
            var domainEvaluator = await _estimatorRepository.GetByKeyAsync(id);

            if (domainEvaluator == null)
            {
                throw new ArgumentException("Application not found");
            }

            var deleteEvaluator = await _estimatorRepository.DeleteAsync(domainEvaluator);
            await _estimatorRepository.SaveChangesAcync();

            return _mapper.Map<EvaluatorDTO>(deleteEvaluator);
        }

        public async Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync()
        {
            var domainEvaluators = await _estimatorRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<EvaluatorDTO>>(domainEvaluators);
        }

        public async Task<EvaluatorDTO> GetEvaluatorsByIdAsync(int id)
        {
            var domainEvaluator = await _estimatorRepository.GetByKeyAsync(id);

            return _mapper.Map<EvaluatorDTO>(domainEvaluator);
        }

        public async Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            var domainEvaluator = _mapper.Map<Estimator>(evaluator);

            var updateEvaluator = await _estimatorRepository.UpdateAsync(domainEvaluator);
            await _estimatorRepository.SaveChangesAcync();

            return _mapper.Map<EvaluatorDTO>(updateEvaluator);
        }
    }
}