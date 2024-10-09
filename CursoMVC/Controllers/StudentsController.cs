using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class StudentsController : Controller
{
    private static List<Student> students = new List<Student>();

    public IActionResult Index()
    {
        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        student.Id = students.Count + 1;
        students.Add(student);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var student = students.Find(s => s.Id == id);
        return View(student);
    }

    [HttpPost]
    public IActionResult Edit(Student student)
    {
        var existingStudent = students.Find(s => s.Id == student.Id);
        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.DateOfBirth = student.DateOfBirth;
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var student = students.Find(s => s.Id == id);
        return View(student);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = students.Find(s => s.Id == id);
        students.Remove(student);
        return RedirectToAction("Index");
    }
}
