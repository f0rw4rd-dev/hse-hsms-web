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
using HardwareStoreWeb.Models;
using HardwareStoreWeb.Pages.Components;

namespace HardwareStoreWeb.Tests.Components
{
    public class DeleteModelTests
    {
        [Fact]
        public async Task OnGetAsync_ComponentDoesNotExist_ReturnsNotFound()
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

            var pageModel = new DeleteModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            var result = await pageModel.OnGetAsync(5);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_NullId_ReturnsNotFound()
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

            var pageModel = new DeleteModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            var result = await pageModel.OnGetAsync(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_ComponentExists_ReturnsPage()
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

            var pageModel = new DeleteModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            var result = await pageModel.OnGetAsync(3);

            Assert.IsType<PageResult>(result);
            Assert.Equal(db.Components.Last(), pageModel.Component);
        }

        [Fact]
        public async Task OnPostAsync_ComponentDoesNotExist_ReturnsRedirectToPage()
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

            var pageModel = new DeleteModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            var result = await pageModel.OnPostAsync(5);

            Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal(3, db.Components.Count());
        }

        [Fact]
        public async Task OnPostAsync_NullId_ReturnsNotFound()
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

            var pageModel = new DeleteModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            var result = await pageModel.OnPostAsync(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task OnPostAsync_ComponentExists_ReturnsRedirectToPage()
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

            var pageModel = new DeleteModel(db)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            var result = await pageModel.OnPostAsync(1);

            Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal(2, db.Components.Count());
            Assert.Null(db.Components.Find(1));
        }
    }
}
