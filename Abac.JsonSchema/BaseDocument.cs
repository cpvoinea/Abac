using System;

namespace Abac.JsonSchema
{
    class JsonDocument : IDocument
    {
        public ISchema Schema
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IData Data
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public static JsonDocument Parse(string text)
        {
            int startIndex = 0;
            var document = new JsonDocument
            {
                Schema = 
            }
        }

        public void SaveToFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public IValidationResult Validate(IData data)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
