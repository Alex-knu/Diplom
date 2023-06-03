namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement
{
    internal class ProgramsParametrToSubjectAreaElement
    {
        public Guid Id { get; set; }
        public Guid ProgramsParametrId { get; set; }
        public Guid SubjectAreaElementId { get; set; }

        public ProgramsParametr.ProgramsParametr ProgramsParametr { get; set; }
        public ApplicationToFactors.ApplicationToFactors SubjectAreaElement { get; set; }
    }
}