using AutoMapper;
using ITProjectPriceCalculationManager.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.CoreModels.Entities.Application;
using ITProjectPriceCalculationManager.DTOModels.DTO;

namespace ITProjectPriceCalculationManager.Core.Services
{
    public class ApplicationService
    {
        protected readonly IRepository<Application, int> _applicationRepository;
        protected readonly IMapper _mapper;

        public ApplicationService(IRepository<Application, int> applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationDTO> GetApplicationAsync(int id)
        {

            var application = await _applicationRepository.GetByKeyAsync(id);

            return _mapper.Map<ApplicationDTO>(application);
        }

        public async Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync()
        {
            var applications = await _applicationRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ApplicationDTO>>(applications);
        }
        public async Task<ApplicationDTO> GetApplicationsByIdAsync(int id)
        {
            var applications = await _applicationRepository.GetByKeyAsync(id);

            return _mapper.Map<ApplicationDTO>(applications);
        }
        public async Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO dto)
        {
            var Application = _mapper.Map<Application>(dto);
            var newApplication = await _applicationRepository.AddAsync(Application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(newApplication);
        }

        public async Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query)
        {
            var Application = _mapper.Map<Application>(query);
            // foreach(var value in query.Profiles)
            // {
            //     var profile = _mapper.Map<Entities.ProfileEntity.Profile>(value);
            //     await _profileRepository.UpdateAsync(profile);
            //     await _applicationRepository.SaveChangesAcync();
            // }
            var updateApplication = await _applicationRepository.UpdateAsync(Application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(updateApplication);
        }

        public async Task<ApplicationDTO> DeleteApplicationAsync(int id)
        {
            var Application = await _applicationRepository.GetByKeyAsync(id);
            if (Application == null)
            {
                throw new ArgumentException("Application not found");
            }
            var deleteApplication = await _applicationRepository.DeleteAsync(Application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(deleteApplication);
        }
    }
}