using Abac.Business;

namespace Abac.Application.Controls
{
    public interface IAbacControl
    {
        void SetValue(AbacValue value);
        AbacValue GetValue();
    }
}
