using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace possible_vulnerabilities
{
    class HTTP_request_smuggling : IVulnerability
    {
        private readonly String URL;
        public HTTP_request_smuggling(String URL)
        {
            this.URL = URL;
        }

        private readonly String _name = "HTTP Request Smuggling";
        public String Name { get => _name; }

        private readonly String _refrenceSite = "https://portswigger.net/web-security/request-smuggling";
        public String RefrenceSite { get => _refrenceSite; }

    
        public Boolean IsItVulnerable()
        {
            return (CL_TE_TEST() || TE_CL_TEST() || TE_TE_TEST());
        }

        //front-end server uses Content-Length | back-end server uses Transfer-Encoding
        private Boolean CL_TE_TEST()
        {
            throw new NotImplementedException();
        }

        //front-end server uses Transfer-Encoding | back-end server uses Content-Length
        private Boolean TE_CL_TEST()
        {
            throw new NotImplementedException();
        }

        //front-end server uses Transfer-Encoding | back-end server uses Transfer-Encoding
        private Boolean TE_TE_TEST()
        {
            throw new NotImplementedException();
        }

    }
}
