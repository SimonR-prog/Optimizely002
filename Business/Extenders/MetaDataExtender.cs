using EPiServer.Shell.ObjectEditing;

namespace Optimizely002.Business.Extenders;

public class MetaDataExtender : IMetadataExtender
{
    public void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
    {
        foreach (var property in metadata.Properties) 
        {
            if (property.PropertyName == "icategorizable_category")
            {
                property.GroupName = "EPiServerCMS_SettingsPanel";
                property.Order = 1;
            }
        }
    }
}
