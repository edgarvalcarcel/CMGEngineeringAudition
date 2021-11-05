using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMGEngineeringAudition.Application.Features.Queries.GetCodeTableContentQuery;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Application.IntegrationTests
{
    using static Testing;
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestClass]
    public class GetCodeTableContentTest
    {
        [Test]
        public async Task ShouldReturnProductInfoItems()
        {
            var query = new GetCodeTableContentQuery
            {
                CodeTableName = "AllocationPerspective"
            };
            var result = await SendAsync(query);
            result.Data.CodeTableItems.Should().NotBeNull();
            result.Data.CodeTableItems.Count.Should().BeGreaterThan(0);
            result.Data.CodeTableItems.Should().NotBeNullOrEmpty();
        }
        [Test]
        public async Task BadRequestProductInfoItems()
        {
            var query = new GetCodeTableContentQuery
            {
                CodeTableName = ""
            };
            try
            {
                var result = await SendAsync(query);
                result.Data.CodeTableItems.Should().NotBeNull();
                result.Data.CodeTableItems.Count.Should().BeGreaterThan(0);
                result.Data.CodeTableItems.Should().NotBeNullOrEmpty();
            }
            catch (System.Exception exc)
            {
                Assert.AreEqual("Expected result.Data.CodeTableItems.Count to be greater than 0, but found 0.", exc.Message);
            }
        }

    }
}
