using System;

namespace CodeRedLauncher
{
    public class SettingBase
    {
        public string Name { get; set; }
        protected string Value
        {
            get { return (IsNull() ? DefaultValue : CurrentValue); }
            set { CurrentValue = value; }
        }
        protected string CurrentValue { get; set; }
        protected string DefaultValue { get; set; }

        public SettingBase(string name, string defaultValue)
        {
            Name = name;
            CurrentValue = defaultValue;
            DefaultValue = defaultValue;
        }

        public bool IsNull() { return String.IsNullOrEmpty(CurrentValue); }
    }

    public class PublicSetting : SettingBase
    {
        public string Label { get; set; }
        public string Description { get; set; }
        private Action SaveCallback { get; set; }

        public PublicSetting(string defaultValue, string name, string label, string description, Action saveCallback = null) : base(name, defaultValue)
        {
            Label = label;
            Description = description;
            SaveCallback = saveCallback;
        }

        public PublicSetting Save() { SaveCallback?.Invoke(); return this; }
        public PublicSetting ResetToDefault() { CurrentValue = DefaultValue; return this; }

        // Functions that modify the current settings value by calling "ToString" automatically depending on their type.
        public PublicSetting SetValue(string newValue) { Value = newValue; return this; }
        public PublicSetting SetValue(bool newValue) { return SetValue(newValue.ToString()); }
        public PublicSetting SetValue(Int32 newValue) { return SetValue(newValue.ToString()); }
        public PublicSetting SetValue(Int64 newValue) { return SetValue(newValue.ToString()); }
        public PublicSetting SetValue(float newValue) { return SetValue(newValue.ToString()); }
        public PublicSetting SetValue(decimal newValue) { return SetValue(newValue.ToString()); }
        public PublicSetting SetValue(double newValue) { return SetValue(newValue.ToString()); }
        public PublicSetting SetValue(Architecture.Path newValue) { return SetValue(newValue.GetPath()); }

        // Return functions that automatically parse value types from the current settings value.

        public string GetStringValue(bool bDefault = false) { return (bDefault ? DefaultValue : Value); }

        public bool GetBoolValue(bool bDefault = false)
        {
            bool succeeded = false;
            bool parsedValue = Boolean.TryParse(bDefault ? DefaultValue : Value, out succeeded);
            return (succeeded ? parsedValue : false);
        }

        public Int32 GetInt32Value(bool bDefault = false)
        {
            bool succeeded = false;
            Int32 parsedValue = 0;
            succeeded = Int32.TryParse(bDefault ? DefaultValue : Value, out parsedValue);
            return (succeeded ? parsedValue : 0);
        }

        public Int64 GetInt64Value(bool bDefault = false)
        {
            bool succeeded = false;
            Int64 parsedValue = 0;
            succeeded = Int64.TryParse(bDefault ? DefaultValue : Value, out parsedValue);
            return (succeeded ? parsedValue : 0);
        }

        public float GetFloatValue(bool bDefault = false)
        {
            bool succeeded = false;
            float parsedValue = 0;
            succeeded = float.TryParse(bDefault ? DefaultValue : Value, out parsedValue);
            return (succeeded ? parsedValue : 0.0f);
        }

        public double GetDoubleValue(bool bDefault = false)
        {
            bool succeeded = false;
            double parsedValue = 0;
            succeeded = double.TryParse(bDefault ? DefaultValue : Value, out parsedValue);
            return (succeeded ? parsedValue : 0.0d);
        }

        public Architecture.Path GetPathValue(bool bDefault = false)
        {
            return new Architecture.Path(bDefault ? DefaultValue : Value);
        }

        public T GetEnumValue<T>(bool bDefault = false)
        {
            bool succeeded = false;
            object parsedValue = default(T);
            succeeded = Enum.TryParse(typeof(T), (bDefault ? DefaultValue : Value), out parsedValue);
            return (T)parsedValue;
        }
    }

    public class PrivateSetting : PublicSetting
    {
        public PrivateSetting(string defaultValue = "") : base(defaultValue, null, null, null) { }
    }

    public class InternalSetting : PublicSetting
    {
        public InternalSetting(string defaultValue, string name) : base(defaultValue, name, null, null) { }
    }
}