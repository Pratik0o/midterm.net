using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class StudentController : Controller
{
    private static List<Student> students = new List<Student>();

    public IActionResult Index()
    {
        return View(students);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            student.StudentId = students.Count + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
        return View(student);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var student = students.FirstOrDefault(s => s.StudentId == id);
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentId == student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.EmailAddress = student.EmailAddress;
            }
            return RedirectToAction("Index");
        }
        return View(student);
    }

    public IActionResult Delete(int id)
    {
        var student = students.FirstOrDefault(s => s.StudentId == id);
        if (student != null)
        {
            students.Remove(student);
        }
        return RedirectToAction("Index");
    }
}
