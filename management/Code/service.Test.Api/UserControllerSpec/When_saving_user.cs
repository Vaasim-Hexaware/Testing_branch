using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using service.Entities.Entities;

namespace service.Test.Api.UserControllerSpec
{
    public class When_saving_user : UsingUserControllerSpec
    {
        private ActionResult<User> _result;

        private User _user;

        public override void Context()
        {
            base.Context();

            _user = new User
            {
                username = "username",
                id = 34
            };

            _userService.Save(_user).Returns(_user);
        }
        public override void Because()
        {
            _result = subject.Save(_user);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _userService.Received(1).Save(_user);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<User>();

            var resultList = (User)resultListObject;

            resultList.ShouldBe(_user);
        }
    }
}
