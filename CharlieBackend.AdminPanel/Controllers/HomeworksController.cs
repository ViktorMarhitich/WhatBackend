﻿using CharlieBackend.AdminPanel.Services.Interfaces;
using CharlieBackend.Core.DTO.Homework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBackend.AdminPanel.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeworksController : Controller
    {
        private readonly IHomeworkService _homeworkService;

        public HomeworksController(IHomeworkService homeworkService)
        {
            _homeworkService = homeworkService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homeworks = await _homeworkService.GetHomeworks();
            return View(homeworks);
        }

        [HttpGet]
        public async Task<IActionResult> GetHomework(long id)
        {
            var homework = await _homeworkService.GetHomeworkById(id);

            return View(homework);
        }


        [HttpGet]
        public async Task<IActionResult> CreateHomework()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> PostHomework(HomeworkDto homework)
        {
            await _homeworkService.AddHomeworkEndpoint(homework);

            return RedirectToAction("Index", nameof(HomeworksController));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PrepareHomeworkForUpdate(long id)
        {
            ViewBag.CurrentId = id;

            return View("Edit");
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> PutHomework(long id, HomeworkDto homework)
        {
            await _homeworkService.UpdateHomeworkEndpoint(id, homework);

            return RedirectToAction("Index", nameof(HomeworksController));
        }
    }
}
