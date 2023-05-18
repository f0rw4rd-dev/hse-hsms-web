using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using HardwareStoreWeb.Pages.Components;

namespace HardwareStoreWeb.Tests.Components
{
    public class CreateModelTests
    {
        [Fact]
        public async Task OnPostAsync_ReturnsRedirectToPage()
        {
            using var db = new StoreContext(Utilities.Utilities.TestDbContextOptions());

            await db.ComponentTypes.AddRangeAsync(MockData.ComponentTypes);
            await db.Components.AddAsync(MockData.Components[0]);
            await db.Components.AddAsync(MockData.Components[1]);

            await db.SaveChangesAsync();

            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };

            var pageModel = new CreateModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext),
                Component = MockData.Components[2]
            };

            var result = await pageModel.OnPostAsync();

            Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal(3, db.Components.Count());
            Assert.NotNull(db.Components.Find(3));
        }
    }
}
