using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using HardwareStoreWeb.Pages.Components;
using Microsoft.AspNetCore.Routing;

namespace HardwareStoreWeb.Tests.Components
{
    public class IndexModelTests
    {
        [Fact]
        public async Task OnGetAsync_EmptyComponents_PageNumberDefault()
        {
            using var db = new StoreContext(Utilities.Utilities.TestDbContextOptions());
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

            var pageModel = new IndexModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            await pageModel.OnGetAsync();

            Assert.False(pageModel.Component.Any());
            Assert.Null(pageModel.Pagination);
        }

        [Fact]
        public async Task OnGetAsync_ThreeComponents_PageNumberDefault()
        {
            using var db = new StoreContext(Utilities.Utilities.TestDbContextOptions());

            await db.ComponentTypes.AddRangeAsync(MockData.ComponentTypes);
            await db.Components.AddRangeAsync(MockData.Components);

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

            var pageModel = new IndexModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            await pageModel.OnGetAsync();

            Assert.Equal(3, pageModel.Component.Count());
            Assert.Equal(3, pageModel.Pagination.TotalCount);
            Assert.Equal(db.Components, pageModel.Pagination.Items);
        }
    }
}
