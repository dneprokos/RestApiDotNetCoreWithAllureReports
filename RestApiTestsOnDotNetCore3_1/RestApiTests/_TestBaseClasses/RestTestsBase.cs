using System;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace RestApiTestsOnDotNetCore3_1.RestApiTests._TestBaseClasses
{
    [AllureNUnit]
    public class RestTestsBase
    {
        [OneTimeSetUp]
        public void BeforeFeature()
        {
            Console.WriteLine("Running before feature");
        }

        [SetUp]
        public virtual void BeforeEachMethod()
        {
            Console.WriteLine("Running API test: " + TestContext.CurrentContext.Test.MethodName);
        }

        [TearDown]
        public virtual void AfterEachMethod()
        {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome);
        }

        [OneTimeTearDown]
        public void AfterFeature()
        {

        }
    }
}
