namespace Abac.JsonSchema
{
    interface ISchema : IData
    {
        IUri Id { get; set; }
        IUri Schema { get; set; }

        IString Title { get; set; }
        IString Description { get; set; }
        IValue Default { get; set; }

        IPositiveNumberExclusive MultipleOf { get; set; }
        INumber Maximum { get; set; }
        IBooleanDefaultFalse ExclusiveMaximum { get; set; }
        INumber Minimum { get; set; }
        IBooleanDefaultFalse ExclusiveMinimum { get; set; }

        IPositiveInteger MaxLength { get; set; }
        IPositiveIntegerDefault0 MinLength { get; set; }
        IRegEx Pattern { get; set; }

        IBooleanOrSchemaDefaultEmpty AdditionalItems { get; set; }
        IArrayOfSchemasMin1OrSchemaDefaultEmpty Items { get; set; }
        IPositiveInteger MaxItems { get; set; }
        IPositiveIntegerDefault0 MinItems { get; set; }
        IBooleanDefaultFalse UniqueItems { get; set; }

        IPositiveInteger MaxProperties { get; set; }
        IPositiveIntegerDefault0 MinProperties { get; set; }
        IArrayOfStringsMin1Unique Required { get; set; }
        IBooleanOrSchemaDefaultEmpty AdditionalProperties { get; set; }

        IObjectOfSchemasDefaultEmpty Definitions { get; set; }
        IObjectOfSchemasDefaultEmpty Properties { get; set; }
        IObjectOfSchemasDefaultEmpty PatternProperties { get; set; }
        IObjectOfSchemasOrArraysOfStringsMin1Unique Dependencies { get; set; }

        IDocumentForm GenerateForm();

        IArrayMin1Unique Enum { get; set; }
        IStringOrArrayMin1Unique Type { get; set; }
        IArrayOfSchemasMin1 AllOf { get; set; }
        IArrayOfSchemasMin1 AnyOf { get; set; }
        IArrayOfSchemasMin1 OneOf { get; set; }
        ISchema Not { get; set; }

        IString Format { get; set; }
    }
}
