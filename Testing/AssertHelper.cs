using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DrawingApp;
using System.Reflection;
using System.Collections;
using System.Linq;

namespace Testing
{
    public class AssertHelper
    {
        public static bool AreEqual(object expected, object actual, out string errorMsg)
        {
            bool result = true;
            errorMsg = null;

            PropertyInfo[] properties = expected.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object expectedValue = property.GetValue(expected, null);
                object actualValue = property.GetValue(actual, null);

                if (!Equals(expectedValue, actualValue))
                {
                    result = false;
                    errorMsg = string.Format("Property {0} does not match {1}. Expected: {2} but was: {3}", property.DeclaringType.Name, property.Name, expectedValue, actualValue);
                    break;
                }
            }

            return result;
        }

        public static void AssertEqual(object expected, object actual)
        {
            string errorMsg = null;
            if(!AreEqual(expected, actual, out errorMsg))
            {
                Assert.Fail(errorMsg);
            }
        }

        public static void ListsAreEqual<T>(List<T> expected, List<T> actual)
        {
            if (expected.Count != actual.Count)
            {
                Assert.Fail("Expected IList with {0} elements but was IList with {1} elements.", expected.Count, actual.Count);
            }
            else
            {
                for (int i = 0; i < expected.Count; i++)
                {
                    AssertEqual(expected[i], actual[i]);
                }
            }
        }

        public static void ListsAreEquivalent<T>(List<T> expected, List<T> actual)
        {
            if (expected.Count != actual.Count)
            {
                Assert.Fail("Expected IList with {0} elements but was IList with {1} elements.", expected.Count, actual.Count);
            }
            else
            {
                HashSet<T> tempSet = new HashSet<T>(expected);
                string equalErrorMsg = null;

                for (int i = 0; i < actual.Count; i++)
                {
                    T foundElement = (T) tempSet.Where(item => AreEqual(item, actual[i], out equalErrorMsg)).FirstOrDefault();
                    if (foundElement != null)
                    {
                        tempSet.Remove(foundElement);
                    }
                    else
                    {
                        Assert.Fail("Expected IList does not contain IList element {0} at index {1}.", actual[i], i);
                    }
                }

                if (tempSet.Count > 0)
                {
                    Assert.Fail("Expected IList elements missing from actual IList. Number of missing elements: {0}", tempSet.Count);
                }
            }
        }
    }
}
