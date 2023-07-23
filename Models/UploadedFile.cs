namespace DBSchoolManagementSystem.Controllers
{
    internal class UploadedFile
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int AssignmentId { get; internal set; }
    }
}