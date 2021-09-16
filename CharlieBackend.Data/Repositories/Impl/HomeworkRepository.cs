﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CharlieBackend.Data.Helpers;
using CharlieBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using CharlieBackend.Data.Repositories.Impl.Interfaces;
using CharlieBackend.Core.DTO.Homework;
using CharlieBackend.Core;

namespace CharlieBackend.Data.Repositories.Impl
{
    public class HomeworkRepository : Repository<Homework>, IHomeworkRepository
    {
        public HomeworkRepository(ApplicationContext applicationContext)
        : base(applicationContext)
        {
        }

        public async override Task<Homework> GetByIdAsync(long homeworkId)
        {
            return await _applicationContext.Homeworks
                        .Include(x => x.Lesson)
                        .Include(x => x.AttachmentsOfHomework)
                        .FirstOrDefaultAsync(x => x.Id == homeworkId);
        }

        public void UpdateManyToMany(IEnumerable<AttachmentOfHomework> currentHomeworkAttachments,
                             IEnumerable<AttachmentOfHomework> newHomeworkAttachments)
        {
            _applicationContext.AttachmentsOfHomework.
                    TryUpdateManyToMany(currentHomeworkAttachments, newHomeworkAttachments);
        }

        public async Task<IList<Homework>> GetHomeworksByLessonId(long lessonId)
        {
            return await _applicationContext.Homeworks
                .Include(x => x.Lesson)
                .Include(x => x.AttachmentsOfHomework)
                .Where(x => x.LessonId == lessonId).ToListAsync();
        }

        public async Task<IList<Homework>> GetHomeworksForMentorByCourseId(long courseId)
        {
            return await _applicationContext.Homeworks
                   .Include(m => m.Lesson)
                   .Include(m => m.AttachmentsOfHomework)
                   .Where(l => l.Lesson.StudentGroup.CourseId == courseId)

                   .ToListAsync();
        }
        public async Task<IList<Homework>> GetHomeworks(GetHomeworksRequestDto request)
        {
            return await _applicationContext.Homeworks
                    .Include(m => m.Lesson)
                    .Include(m => m.AttachmentsOfHomework)
                    .WhereIf(request.GroupId != 0,
                            l => l.Lesson.StudentGroupId == request.GroupId)
                    .WhereIf(request.ThemeId != 0,
                            t => t.Lesson.ThemeId == request.ThemeId)
                    .WhereIf(request.CourseId != 0,
                            l => l.Lesson.StudentGroup.CourseId == request.CourseId)
                    .WhereIf(request.StartDate != default,
                            d => d.PublishingDate >= request.StartDate)
                    .WhereIf(request.FinishDate != default,
                            d => d.PublishingDate <= request.FinishDate)

                    .ToListAsync();
        }

        public async Task<Homework> GetMentorHomeworkAsync(long mentorId, long homeworkId)
        {
            return await _applicationContext.Homeworks
                .Include(x => x.Lesson)
                .FirstOrDefaultAsync(x => (x.Id == homeworkId) && (x.Lesson.MentorId == mentorId));
        }

    }
}
