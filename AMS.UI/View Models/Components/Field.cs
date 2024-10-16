namespace AMS.UI.View_Models.Components
{
    enum FieldType
    {
        STRING,
        BOOLEAN,
        DATETIME
    }

    internal class Field
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; } = false;
        public string Error { get; private set; }
        public FieldType FieldType { get; set; } = FieldType.STRING;
        public bool IsPresent { get { return !string.IsNullOrEmpty(Value); } }
        public bool IsValid { get { return string.IsNullOrEmpty(Error); } }

        public void SetError(string error)
        {
            Error = error;
        }

        public void RemoveError()
        {
            Error = null;
        }

    }
}
