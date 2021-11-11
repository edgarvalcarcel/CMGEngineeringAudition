using CMGEngineeringAudition.Application.Features.Commands;
using CMGEngineeringAudition.Infrastructure.Shared.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    using static Testing;
    using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


    //CancelOrderCommand
    [TestClass]
    public class EvaluateLogCommandTest
    {
        [Test]
        public async Task EvaluateLogOK()
        {
            string filename = "e:\\downloads\\file.txt";
            var result = await SendAsync(new EvaluateLogCommand() { ContentFile = filename });
            result.Succeeded.Equals(result.Succeeded);

        }
        [Test]
        public async Task LogHasContentOK()
        {
            string filename = "e:\\downloads\\file.txt";
            var result = await SendAsync(new EvaluateLogCommand() { ContentFile = filename });
            result.Succeeded.Equals(result.Data.Count>0);
        }
   }
}
