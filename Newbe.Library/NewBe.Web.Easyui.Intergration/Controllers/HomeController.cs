using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBe.Web.Easyui.Intergration.DataModels;
using NewBe.Web.Easyui.Intergration.ViewModels;

namespace NewBe.Web.Easyui.Intergration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataStore _dataStore;

        public HomeController()
        {
            _dataStore = new StaticDataStore();
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Students(StudentGridParameter studentGridParameter)
        {
            var students = _dataStore.Students;
            var grades = _dataStore.Grades.ToDictionary(x => x.Id);
            var classes = _dataStore.Classes.ToDictionary(x => x.Id);
            IEnumerable<Student> data = students;
            if (!string.IsNullOrEmpty(studentGridParameter.ClassId))
            {
                data = data.Where(x => x.ClassId == studentGridParameter.ClassId);
            }
            if (!string.IsNullOrEmpty(studentGridParameter.GradeId))
            {
                var classesIds =
                    classes.Where(x => x.Value.GradeId == studentGridParameter.GradeId).Select(x => x.Value.Id);
                data = data.Where(x => classesIds.Contains(x.ClassId));
            }
            var studentsResult = data
                .EasyuiSort(studentGridParameter)
                .Skip((studentGridParameter.Page - 1) * studentGridParameter.Rows)
                .Take(studentGridParameter.Rows)
                .Select(x => new StudentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Sex = x.Sex,
                    Birthday = x.Birthday,
                    ClassId = x.ClassId,
                    ClassName = classes[x.ClassId].Name,
                    GradeId = classes[x.ClassId].GradeId,
                    GradeName = grades[classes[x.ClassId].GradeId].Name,
                })
                .AsEnumerable();
            var viewResult = studentsResult.AsEasyuiList().ToDatagridResult(students.Count);
            return Json(viewResult);
        }

        public class ClassesComboboxParameter : IEasyuiAccept
        {
            public string GradeId { get; set; }
            public EasyuiAcceptType Accept { get; set; }
        }

        public JsonResult Classes(ClassesComboboxParameter classesComboboxParameter)
        {
            IEnumerable<Class> data = _dataStore.Classes;
            if (!string.IsNullOrEmpty(classesComboboxParameter.GradeId))
            {
                data = data.Where(x => x.GradeId == classesComboboxParameter.GradeId);
            }
            var viewResult = data.AsEasyuiList().FormateByAccept(classesComboboxParameter);
            return Json(viewResult);
        }

        public JsonResult Grades(EasyuiAcceptType accept)
        {
            var grades = _dataStore.Grades;
            var viewResult = grades.AsEasyuiList().FormateByAccept(accept);
            return Json(viewResult);
        }
    }
}