namespace Abac.JsonSchema
{
    interface IDocumentForm
    {
        IDocument Document { get; set; }

        void SetData(IData data);
        IData GetData();
    }
}
