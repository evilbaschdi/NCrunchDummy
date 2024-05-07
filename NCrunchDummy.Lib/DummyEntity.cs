using Microsoft.Xrm.Sdk;

namespace NCrunchDummy.Lib;

public class DummyEntity : IDummyEntity
{
    public Entity Value
    {
        get
        {
            var entity = new Entity("dummy")
                         {
                             Attributes = new AttributeCollection
                                          {
                                              { "title", "ncrunch" },
                                              { "version", "v5" },
                                              { "net", "8.0" }
                                          }
                         };

            return entity;
        }
    }
}