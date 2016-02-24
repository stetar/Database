using System.Collections.Generic;

namespace Working_title.MapGenerator
{
    public interface Builder
    {
        List<BuildObject> Build();
    }
}