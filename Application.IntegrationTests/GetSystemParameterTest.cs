using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;


namespace Application.IntegrationTests
{
    using static Testing;
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

    [TestClass]
    class GetSystemParameterTest
    {
        [Test]
        public async Task ShouldReturnProductInfoItems()
        {
            var query = new SystemParameterContentQuery
            {
                KeyName = "VALIDITYDATE"
            };
            var result = await SendAsync(query);
            result.Data.KeyValue.Should().NotBeNull();
            result.Data.KeyValue.Should().NotBeNullOrEmpty();
        }
        [Test]
        public async Task BadRequestProductInfoItems()
        {
            var query = new SystemParameterContentQuery
            {
                KeyName = ""
            };

            var result = await SendAsync(query);

            Assert.AreEqual(null, result.Data);


        }

    }
}
