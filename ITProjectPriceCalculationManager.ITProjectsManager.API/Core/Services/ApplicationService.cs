using AutoMapper;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Repositories;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services
{
    internal class ApplicationService : IApplicationService
    {
        protected readonly IRepository<Application, int> _applicationRepository;
        protected readonly IMapper _mapper;

        public ApplicationService(IRepository<Application, int> applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
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
            var application = _mapper.Map<Application>(dto);
            var newApplication = await _applicationRepository.AddAsync(application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(newApplication);
        }

        public async Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query)
        {
            var application = _mapper.Map<Application>(query);

            // foreach(var value in query.Profiles)
            // {
            //     var profile = _mapper.Map<Entities.ProfileEntity.Profile>(value);
            //     await _profileRepository.UpdateAsync(profile);
            //     await _applicationRepository.SaveChangesAcync();
            // }

            var updateApplication = await _applicationRepository.UpdateAsync(application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(updateApplication);
        }

        public async Task<ApplicationDTO> DeleteApplicationAsync(int id)
        {
            var application = await _applicationRepository.GetByKeyAsync(id);

            if (application == null)
            {
                throw new ArgumentException("Application not found");
            }

            var deleteApplication = await _applicationRepository.DeleteAsync(application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(deleteApplication);
        }

        public async Task<ApplicationDTO> CreateBaseApplicationAsync(BaseApplicationDTO baseApplication)
        {
            var application = _mapper.Map<Application>(baseApplication);
            var newApplication = await _applicationRepository.AddAsync(application);
            await _applicationRepository.SaveChangesAcync();

            return _mapper.Map<ApplicationDTO>(newApplication);
        }
    }
}