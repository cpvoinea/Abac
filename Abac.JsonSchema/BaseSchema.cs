namespace Abac.JsonSchema
{
    class BaseSchema : ISchema
    {
        #region Keywords

        public IBooleanOrSchemaDefaultEmpty AdditionalItems { get; set; }

        public IBooleanOrSchemaDefaultEmpty AdditionalProperties { get; set; }

        public IArrayOfSchemasMin1 AllOf { get; set; }

        public IArrayOfSchemasMin1 AnyOf { get; set; }

        public IValue Default { get; set; }

        public IObjectOfSchemasDefaultEmpty Definitions { get; set; }

        public IObjectOfSchemasOrArraysOfStringsMin1Unique Dependencies { get; set; }

        public IString Description { get; set; }

        public IArrayMin1Unique Enum { get; set; }

        public IBooleanDefaultFalse ExclusiveMaximum { get; set; }

        public IBooleanDefaultFalse ExclusiveMinimum { get; set; }

        public IString Format { get; set; }

        public IUri Id { get; set; }

        public IArrayOfSchemasMin1OrSchemaDefaultEmpty Items { get; set; }

        public INumber Maximum { get; set; }

        public IPositiveInteger MaxItems { get; set; }

        public IPositiveInteger MaxLength { get; set; }

        public IPositiveInteger MaxProperties { get; set; }

        public INumber Minimum { get; set; }

        public IPositiveIntegerDefault0 MinItems { get; set; }

        public IPositiveIntegerDefault0 MinLength { get; set; }

        public IPositiveIntegerDefault0 MinProperties { get; set; }

        public IPositiveNumberExclusive MultipleOf { get; set; }

        public ISchema Not { get; set; }

        public IArrayOfSchemasMin1 OneOf { get; set; }

        public IRegEx Pattern { get; set; }

        public IObjectOfSchemasDefaultEmpty PatternProperties { get; set; }

        public IObjectOfSchemasDefaultEmpty Properties { get; set; }

        public IArrayOfStringsMin1Unique Required { get; set; }

        public IUri Schema { get; set; }

        public IString Title { get; set; }

        public IStringOrArrayMin1Unique Type { get; set; }

        public IBooleanDefaultFalse UniqueItems { get; set; }

        #endregion
    }
}
