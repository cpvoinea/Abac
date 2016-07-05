using System.Collections.Generic;

namespace Abac.JsonSchema
{
    interface IObject : IContainerValue, IDictionary<string, IValue>
    {
    }
}
