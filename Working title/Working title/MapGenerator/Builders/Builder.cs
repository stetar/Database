using System.Collections.Generic;

namespace Working_title.MapGenerator
{
    public delegate void BuilderCallback(List<BuildObject> buildObjects);

    public interface Builder
    {
        void Build(BuilderCallback builderCallback);
    }
}