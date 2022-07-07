using NSubstitute;
using service.Test.Framework;
using service.Api.Controllers;
using service.Business.Interfaces;


namespace service.Test.Api.UserControllerSpec
{
    public abstract class UsingUserControllerSpec : SpecFor<UserController>
    {
        protected IUserService _userService;

        public override void Context()
        {
            _userService = Substitute.For<IUserService>();
            subject = new UserController(_userService);

        }

    }
}
