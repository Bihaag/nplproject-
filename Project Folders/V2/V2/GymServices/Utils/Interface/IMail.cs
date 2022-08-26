using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices.Utils.Interface
{
    public interface IMail
    {
        void EmailSend(string body, string to, string subject);
    }
}
