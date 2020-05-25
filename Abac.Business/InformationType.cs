using System.Collections.Generic;

namespace Abac.Business
{
    public class InformationType
    {
        public string Name { get; set; }
        public BaseType? BaseType { get; set; }
        public List<InformationTypeDetail> Details { get; set; }

        public bool IsBaseType { get { return BaseType.HasValue; } }

        public string GetDetailsString()
        {
            return IsBaseType ?
                (BaseType != Business.BaseType.Options ? BaseType.Value.ToString() : InformationTypes.GetOptionsString(Details)) :
                InformationTypes.GetDetailsString(Details);
        }
    }
}
