using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement;

internal class ProgramsParametrToSubjectAreaElement : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ProgramsParametrId { get; set; }
    public Guid SubjectAreaElementId { get; set; }

    public ProgramsParametr.ProgramsParametr? ProgramsParametr { get; set; }
    public ApplicationToFactor.ApplicationToFactor? SubjectAreaElement { get; set; }
}