namespace Sitecore.Support.XA.Feature.Maps.Repositories
{
  using Sitecore.Data;
  using Sitecore.Web;
  using Sitecore.XA.Foundation.Geospatial.Services;
  using System.Collections.Generic;

  public class MapsRepository : Sitecore.XA.Feature.Maps.Repositories.MapsRepository
  {
    private Dictionary<ID, ID> _typeToVariantMapping;
    protected override Dictionary<ID, ID> TypeToVariantMapping
    {
      get
      {
        if (_typeToVariantMapping == null)
        {
          _typeToVariantMapping = new Dictionary<ID, ID>();
          string typeToVariantMappings = Rendering.DataSourceItem[Sitecore.XA.Feature.Maps.Templates.Map.Fields.TypeToVariantMapping];
          if (!string.IsNullOrEmpty(typeToVariantMappings))
          {
            var ids = WebUtil.ParseUrlParameters(typeToVariantMappings);
            foreach (string typeId in ids.AllKeys)
            {
              if (!string.IsNullOrWhiteSpace(ids[typeId]))
              {
                _typeToVariantMapping.Add(ID.Parse(typeId), ID.Parse(ids[typeId]));
              }
            }
          }
        }
        return _typeToVariantMapping;
      }
    }

    public MapsRepository(IMapsProvider mapsProvider) : base(mapsProvider) { }

  }
}