namespace Abac.JsonSchema
{
    interface IDocument : IData
    {
        ISchema Schema { get; set; }
        IData Data { get; set; }

        void SaveToFile(string filePath);
        IValidationResult Validate(IData data);
    }
}
