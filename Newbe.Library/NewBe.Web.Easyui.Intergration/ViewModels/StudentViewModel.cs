using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewBe.Web.Easyui.Combobox;
using NewBe.Web.Easyui.Intergration.DataModels;

namespace NewBe.Web.Easyui.Intergration.ViewModels
{
    public class StudentViewModel
    {
        [EasyuiComboboxValue]
        public string Id { get; set; }

        [EasyuiComboboxText]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public SexType Sex { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string GradeId { get; set; }
        public string GradeName { get; set; }
    }
}