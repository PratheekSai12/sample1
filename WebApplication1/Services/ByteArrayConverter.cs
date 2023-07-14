using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WebApplication1.Services
{
    public class ByteArrayConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(byte[]);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(byte[]);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is byte[][] byteArrayArray && destinationType == typeof(byte[]))
            {
                using (var stream = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, byteArrayArray);
                    return stream.ToArray();
                }
            }
            return null;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is byte[] byteArray)
            {
                using (var stream = new MemoryStream(byteArray))
                {
                    var formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream) as byte[][];
                }
            }
            return null;
        }
    }

}
