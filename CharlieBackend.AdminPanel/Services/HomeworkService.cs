﻿using AutoMapper;
using CharlieBackend.AdminPanel.Models.Homework;
using CharlieBackend.AdminPanel.Services.Interfaces;
using CharlieBackend.AdminPanel.Utils.Interfaces;
using CharlieBackend.Core.DTO.Homework;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharlieBackend.AdminPanel.Services
{
    public class HomeworkService : IHomeworkService
    {
        private readonly HomeworksApiEndpoints _homeworkApiEndpoints;
        private readonly IApiUtil _apiUtil;
        private readonly IMapper _mapper;

        public HomeworkService(IApiUtil iApiUtil, IMapper mapper, IOptions<ApplicationSettings> options)
        {
            _apiUtil = iApiUtil;
            _mapper = mapper;
            _homeworkApiEndpoints = options.Value.Urls.ApiEndpoints.Homeworks;
        }

        public async Task<IList<HomeworkViewModel>> GetHomeworks()
        {
            var homeworksEndpint = _homeworkApiEndpoints.GetHomeworks;
            return await _apiUtil.GetAsync<IList<HomeworkViewModel>>(homeworksEndpint);
        }

        public async Task AddHomeworkEndpoint(HomeworkDto homeworkDto)
        {
            var addHomeworkEndpoint = _homeworkApiEndpoints.AddHomeworkEndpoint;

            await _apiUtil.CreateAsync(addHomeworkEndpoint, homeworkDto);
        }

        public async Task<HomeworkViewModel> GetHomeworkById(long id)
        {
            var getHomeworkById = string.Format(_homeworkApiEndpoints.GetHomeworkById, id); 
            var homeworkDto = await _apiUtil.GetAsync<HomeworkDto>(getHomeworkById);
            return _mapper.Map<HomeworkViewModel>(homeworkDto); 
        }

        public async Task UpdateHomeworkEndpoint(long id, HomeworkDto homeworkDto)
        {
            var updateHomeworkEndpoint = string.Format(_homeworkApiEndpoints.UpdateHomeworkEndpoint, id);

            await _apiUtil.PutAsync(updateHomeworkEndpoint, homeworkDto);
        }
    }
}
