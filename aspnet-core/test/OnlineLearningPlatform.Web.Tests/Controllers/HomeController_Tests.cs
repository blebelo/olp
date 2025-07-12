using System.Threading.Tasks;
using OnlineLearningPlatform.Models.TokenAuth;
using OnlineLearningPlatform.Web.Controllers;
using Shouldly;
using Xunit;

namespace OnlineLearningPlatform.Web.Tests.Controllers
{
    public class HomeController_Tests: OnlineLearningPlatformWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}