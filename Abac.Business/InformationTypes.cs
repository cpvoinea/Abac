using System.Collections.Generic;
using System.Text;

namespace Abac.Business
{
    public static class InformationTypes
    {
        static readonly Dictionary<string, InformationType> _types = new Dictionary<string, InformationType>();

        static InformationTypes()
        {
            _types.Add("Text", new InformationType { Name = "Text", BaseType = BaseType.Text });
            _types.Add("Integer", new InformationType { Name = "Integer", BaseType = BaseType.Integer });
            _types.Add("Real", new InformationType { Name = "Real", BaseType = BaseType.Real });
            _types.Add("Date", new InformationType { Name = "Date", BaseType = BaseType.Date });
            _types.Add("Boolean", new InformationType
            {
                Name = "Boolean",
                BaseType = BaseType.Options,
                Details = new List<InformationTypeDetail>(new[]
                {
                    new InformationTypeDetail { Name = "True" },
                    new InformationTypeDetail { Name = "False" }
                })
            });
        }

        public static Dictionary<string, InformationType> Types { get { return _types; } }

        internal static string GetOptionsString(List<InformationTypeDetail> details)
        {
            if (details == null || details.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder(details[0].Name);
            for (int i = 1; i < details.Count; i++)
            {
                sb.Append(", ");
                sb.Append(details[i].Name);
            }

            return sb.ToString();
        }

        internal static string GetDetailsString(List<InformationTypeDetail> details)
        {
            if (details == null || details.Count == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder("{ ");
            foreach(var d in details)
            {
                sb.Append(d.Name);
                sb.Append(": ");
                sb.Append(d.Type.Name);
                sb.Append("; ");
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}
