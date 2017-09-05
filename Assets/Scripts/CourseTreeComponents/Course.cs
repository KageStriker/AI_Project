﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Course
{
    public int coursePrice;
    public string name;
    public List<Student> studentsEnrolled;
    public List<Course> dependencies;

    public Course(int _coursePrice, string _name)
    {
        coursePrice = _coursePrice;
    }

    public void AddStudent(Student _student)
    {
        studentsEnrolled.Add(_student);
    }

    public void AddDependency(Course _dependency)
    {
        dependencies.Add(_dependency);
    }
}
