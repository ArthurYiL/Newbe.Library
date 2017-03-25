namespace NewBe.Web.Easyui.Intergration.ViewModels
{
    public class StudentGridParameter : IEasyuiPagination, IEasyuiSorter
    {
        public string ClassId { get; set; }
        public string GradeId { get; set; }
        public int Rows { get; set; }
        public int Page { get; set; }
        public SortOrder Order { get; set; }
        public string SortBy { get; set; }
    }
}