using System;
using NUnit.Framework;
using Packages.com.DeHagge.PrivateTestFramework.Runtime;

namespace Packages.com.DeHagge.PrivateTestFramework.Tests
{
    public class TestFixtureTests
    {
        private class TestObj
        {
            private string fieldString = "abc";
            private int fieldInt = -1;

            private void SetIntToZero()
            {
                fieldInt = 0;
            }
        }

        public class GetPrivateFieldValue : TestFixture
        {
            [Test]
            public void FieldDoesExist_ThenReturnValue()
            {
                var testObj = new TestObj();
                var field = GetPrivateFieldValue<string>(testObj, "fieldString");
                Assert.AreEqual("abc", field);
            }
            
            [Test]
            public void FieldDoesExistButOtherType_ThenThrowException()
            {
                var testObj = new TestObj();
                Assert.Throws<InvalidCastException>(() => GetPrivateFieldValue<string>(testObj, "fieldInt"));
            }
            
            [Test]
            public void FieldDoesNotExist_ThenReturnNull()
            {
                var testObj = new TestObj();
                Assert.IsNull(GetPrivateFieldValue<string>(testObj, "test"));
            }
        }
    }
}