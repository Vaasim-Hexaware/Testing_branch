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
    public class When_getting_all_user : UsingUserControllerSpec
    {
        private ActionResult<IEnumerable<User>> _result;

        private IEnumerable<User> _all_user;
        private User _user;

        public override void Context()
        {
            base.Context();

            _user = new User{
                username = "username",
                id = 83
            };

            _all_user = new List<User> { _user};
            _userService.GetAll().Returns(_all_user);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _userService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<User>>();

            List<User> resultList = resultListObject as List<User>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_user);
        }
    }
}
