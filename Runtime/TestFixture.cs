using System;
using System.Reflection;

namespace Packages.com.DeHagge.PrivateTestFramework.Runtime
{
    public class TestFixture
    {
        protected static T GetPrivateFieldValue<T>(object obj, string privateFieldName)
        {
            var field =
                obj.GetType().GetField(privateFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            return (T) field?.GetValue(obj);
        }

        protected static void SetPrivateFieldValue<T>(object obj, string privateFieldName, T value)
        {
            var field =
                obj.GetType().GetField(privateFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            field?.SetValue(obj, value);
        }

        protected static void InvokePrivateMethod(object obj, string methodName, params object[] methodParams)
        {
            var method = obj.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (method == null)
            {
                throw new InvalidOperationException();
            }

            method.Invoke(obj, methodParams);
        }
        
        protected static T InvokePrivateMethod<T>(object obj, string methodName, params object[] methodParams)
        {
            var method = obj.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (method == null)
            {
                throw new InvalidOperationException();
            }

            return (T) method.Invoke(obj, methodParams);
        }
    }
}