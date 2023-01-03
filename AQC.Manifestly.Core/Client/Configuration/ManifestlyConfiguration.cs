namespace AQC.Manifestly.Core.Client.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ManifestlyConfiguration
    {
        public const string Manifestly = "Manifestly";

        public string BaseUrl { get; set; } = string.Empty;

        public string ServiceApiKey { get; set; } = string.Empty;
    }
}
