using System;
using System.IO;

namespace Truesight.Api.Meta.Core
{
    public interface IResource
    {
        String Name { get; set; }
        String FullName { get; set; }
        String Namespace { get; set; }

        Stream OpenStream();
    }
}