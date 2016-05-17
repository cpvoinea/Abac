using System;
using Abac.Business;
using Abac.Test.Properties;

namespace Abac.Test.Business
{
    internal class TestSerialization : BaseTest
    {
        protected internal override bool RunAllInternal()
        {
            return
                RunTest(ParseTest) &
                RunTest(SerializationTest) &
                RunTest(EqualityTest);
        }

        private static void ParseTest()
        {
            var v = AbacValue.Parse(JsonExample);

            if (!RemoveEmptySpaces(v + "").Equals(RemoveEmptySpaces(JsonExample)))
                throw new ApplicationException("ParseTest failed");
        }

        private static void SerializationTest()
        {
            var json = ValueExample.ToString();
            var parsed = AbacValue.Parse(json);

            if (!parsed.Equals(ValueExample))
                throw new ApplicationException("Parsed value not equal to serialized value");
            if (!parsed.ToString().Equals(json))
                throw new ApplicationException("Parsed value serialization not the same as original serialization");
        }

        private static void EqualityTest()
        {
            var parsed = AbacValue.Parse(ValueExample.ToString());

            if (!parsed.Equals(ValueExample))
                throw new ApplicationException("Parsed value not equal to original");
            if (parsed.GetHashCode() != ValueExample.GetHashCode())
                throw new ApplicationException("Parsed hashed code not equal to original");
            if (!parsed.ToString().Equals(ValueExample + ""))
                throw new ApplicationException("Parsed string not equal to original");
        }

        #region Constants

        private static readonly string JsonExample = Resources.jsonString;

        private static readonly AbacValue ValueExample = new AbacValue(new AbacObject
        {
            {"firstName", new AbacValue("John")},
            {"lastName", new AbacValue("Smith")},
            {"isAlive", new AbacValue(true)},
            {"age", new AbacValue(25)},
            {
                "address", new AbacValue(new AbacObject
                {
                    {"streetAddress", new AbacValue("21 Jump Street")},
                    {"city", new AbacValue("New York")}
                })
            },
            {
                "an array",
                new AbacValue(new AbacArray {new AbacValue("unu"), new AbacValue("doi"), new AbacValue("trei")})
            },
            {
                "phoneNumbers", new AbacValue(new AbacArray
                {
                    new AbacValue(new AbacObject
                    {
                        {"type", new AbacValue("home")},
                        {"number", new AbacValue(555)}
                    }),
                    new AbacValue(new AbacObject
                    {
                        {"type", new AbacValue("office")},
                        {"number", new AbacValue("555")}
                    })
                })
            },
            {"children", new AbacValue(new AbacArray())},
            {"spouse", new AbacValue()}
        });

        #endregion
    }
}