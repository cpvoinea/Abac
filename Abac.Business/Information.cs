using System.Collections.Generic;

namespace Abac.Business
{
    public class Information
    {
        readonly InformationType _type;
        readonly List<Information> _details = new List<Information>();

        public Information this[string name]
        {
            get
            {
                foreach (Information i in _details)
                    if (i.Name == name)
                        return i;
                return null;
            }
            set
            {
                foreach (Information i in _details)
                    if (i.Name == name)
                    {
                        break;
                    }
            }
        }

        public string Name { get { return _type.Name; } }

        public object Value
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        public Information(InformationType type)
        {
            _type = type;
        }
    }
}
