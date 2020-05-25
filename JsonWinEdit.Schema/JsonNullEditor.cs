using JsonWinEdit.Data;

namespace JsonWinEdit.Schema
{
    public class JsonNullEditor : JsonValueEditor
    {
        public JsonNullEditor() : base(null, JsonNull.Value)
        {
        }
    }
}
