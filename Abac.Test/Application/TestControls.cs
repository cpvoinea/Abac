using System;

namespace Abac.Test.Application
{
    internal class TestControls : BaseTest
    {
        private const string example = "{\"firstName\":\"John\",\"lastName\":\"Smith\",\"isAlive\":true,\"age\":25,\"address\":{\"streetAddress\":\"21 2nd Street\",\"city\":\"New York\",\"state\":\"NY\",\"postalCode\":\"10021-3100\"},\"phoneNumbers\":[{\"type\":\"home\",\"number\":\"212555-1234\"},{\"type\":\"office\",\"number\":\"646555-4567\"},{\"type\":\"mobile\",\"number\":\"123456-7890\"}],\"children\":[],\"spouse\":null}";
        private const string cumparaturi = "{\"cumparatura\": \"\",\"cost\":0.0, \"este pe gratis\":false, \"lista optiuni\":[\"oua\",\"mere\",\"lapte\"], \"optiuni cu nume lung si una goala\":[1,2,3,null,5], \"obiect vid\":{},\"lista vida\":[]}";

        protected internal override bool RunAllInternal()
        {
            throw new NotImplementedException();
        }
    }
}
