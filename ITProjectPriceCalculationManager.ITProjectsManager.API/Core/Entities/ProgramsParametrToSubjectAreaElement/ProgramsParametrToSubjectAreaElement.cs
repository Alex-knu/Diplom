namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametrToSubjectAreaElement
{
    internal class ProgramsParametrToSubjectAreaElement
    {
        public int Id { get; set; }
        public int  ProgramsParametrId { get; set; }
        public int  SubjectAreaElementId { get; set; }

        public ProgramsParametr.ProgramsParametr ProgramsParametr{ get; set; }
        public SubjectAreaElement.SubjectAreaElement SubjectAreaElement{ get; set; }
    }
}