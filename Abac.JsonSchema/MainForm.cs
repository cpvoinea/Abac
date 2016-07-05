using System.IO;
using System.Windows.Forms;

namespace Abac.JsonSchema
{
    internal partial class MainForm : Form, IApplication
    {
        readonly string _filePath;
        IDocument _document;
        IDocumentForm _form;

        public MainForm()
        {
            InitializeComponent();
            _filePath = Configuration.DocumentFilePath;
            InitializeApplication();
        }

        void InitializeApplication()
        {
            _document = ReadDocumentFromFile(_filePath);
            if (_document.Validate(_document.Data).Success)
            {
                _form = GenerateFormFromSchema(_document.Schema);
                _form.SetData(_document.Data);
                DisplayDocumentForm(_form);
            }
        }

        void UpdateChanges()
        {
            var data = _form.GetData();
            var result = _document.Validate(data);
            if (result.Success)
            {
                _document.SaveToFile(_filePath);
            }
            else
                DisplayValidationResult(_form, result);
        }

        IDocument ReadDocumentFromFile(string filePath)
        {
            using (var sr = new StreamReader(filePath))
            {
                var text = sr.ReadToEnd();
                return JsonDocument.Parse(text);
            }
        }

        IDocumentForm GenerateFormFromSchema(ISchema schema)
        {
            return schema.GenerateForm();
        }

        void DisplayDocumentForm(IDocumentForm form)
        {
        }

        void DisplayValidationResult(IDocumentForm form, IValidationResult result)
        {
        }
    }
}
