using System.Security.Cryptography.X509Certificates;

namespace Working_title.MapGenerator
{
    public interface Factory
    {
        GameObject CreateObject(Creator creator);
    }
}