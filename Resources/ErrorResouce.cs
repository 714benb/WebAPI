using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Resources
{

    public class ErrorResource
    {
        public bool Success => false;
        public IEnumerable<string> Messages { get; private set; }

        public ErrorResource(IEnumerable<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public ErrorResource(string message)
        {
            Messages = new List<string>();

            if (false == string.IsNullOrWhiteSpace(message))
            {
                ((List<string>) Messages).Add(message);
            }
        }
    }
}
