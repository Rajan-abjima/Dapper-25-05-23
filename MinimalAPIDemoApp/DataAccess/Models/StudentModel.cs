﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;
public class StudentModel
{
    public int RollNo { get; set; }
    public string? Name { get; set; }
    public string? FamilyName { get; set; }
    public string? Address { get; set; }
    public string? Contact { get; set; }
}
