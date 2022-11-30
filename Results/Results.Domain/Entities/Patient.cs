﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Results.Domain.Entities
{
    public class Patient
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Exam> Exams { get; set; }

    }
}