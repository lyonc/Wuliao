using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Clsmap.Wuliao.Mvc.Controllers;
using Clsmap.Wuliao.Mvc.Models;

namespace Clsmap.Wuliao.Mvc.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Detail()
        {
            // Arrange
            var controller = new PostController();

            // Act
            var result = (ViewResult)controller.Detail();
            var model = (PostViewModel)result.Model;

            // Assert
            Assert.AreEqual("Lyon Chen", model.Writer.Name);
            Assert.AreEqual(1, model.Comments.Count);
        }
    }
}
