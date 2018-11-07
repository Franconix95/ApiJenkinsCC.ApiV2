﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiJenkinsCC.ApiV2.API.DataContracts.Requests;
using ApiJenkinsCC.ApiV2.API.DataContracts;
using ApiJenkinsCC.ApiV2.Services;
using AutoMapper;
using S = ApiJenkinsCC.ApiV2.Services.Model;
using ApiJenkinsCC.ApiV2.Services.Contracts;

namespace ApiJenkinsCC.ApiV2.API.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserControllerV2 : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserControllerV2(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region GET
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;
        }
        #endregion

        #region POST
        [HttpPost]
        public async Task<User> CreateUser([FromBody]UserCreationRequest value)
        {

            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");


            var data = await _service.CreateAsync(Mapper.Map<S.User>(value));

            if (data != null)
                return _mapper.Map<User>(data);
            else
                return null;

        }
        #endregion

        #region PUT
        [HttpPut()]
        public async Task<bool> UpdateUser(User parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return await _service.UpdateAsync(Mapper.Map<S.User>(parameter));
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public async Task<bool> DeleteDevice(string id)
        {
            return await _service.DeleteAsync(id);
        }
        #endregion
    }
}
