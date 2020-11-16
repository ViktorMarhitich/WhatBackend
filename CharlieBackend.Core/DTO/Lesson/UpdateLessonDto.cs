﻿using System;
using System.Text;
using System.Collections.Generic;
using CharlieBackend.Core.DTO.Visit;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CharlieBackend.Core.DTO.Lesson
{
    public class UpdateLessonDto
    {
        public long Id { get; set; }

        [StringLength(100)]
        public string ThemeName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LessonDate { get; set; }

        public IList<VisitDto> Visits { get; set; }
    }
}
