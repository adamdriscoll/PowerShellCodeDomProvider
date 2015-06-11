using System.Reflection;
using Microsoft.VisualStudio.Shell.Design.Serialization;

namespace PoshPowerTools.Designer
{
    public static class DocDataExtensions
    {
        public static string GetDesignerFileName(this DocDataTextWriter writer)
        {
            var fileName = writer.GetFileName();

            var index = fileName.LastIndexOf('.');
            return fileName.Insert(index + 1, "Designer.");
        }

        public static string GetDesignerFileName(this DocDataTextReader reader)
        {
            var fileName = reader.GetFileName();

            var index = fileName.LastIndexOf('.');
            return fileName.Insert(index + 1, "Designer.");
        }

        public static string GetFileName(this DocDataTextWriter writer)
        {
            var value = typeof (DocDataTextWriter).GetProperty("DocData", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(writer) as DocData;

            return value.Name;
        }

        public static string GetFileName(this DocDataTextReader reader)
        {
            var value = typeof(DocDataTextReader).GetProperty("DocData", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(reader) as DocData;

            return value.Name;
        }
    }
}
