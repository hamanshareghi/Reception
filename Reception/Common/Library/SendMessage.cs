using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;
namespace Common.Library
{
    public class SendMessage
    {
        public static void SendSMS( string number, string message)
        {
            var sender = "1000596446";
            number = "09121950430";
            message = ".وب سرویس پیام کوتاه کاوه نگار";
            var api = new Kavenegar.KavenegarApi("326C4D6F466E46637061714A747930487875702B3072737671766C7045572F4E4345306456574D713953633D");
            api.Send(sender, number, message);
        }
    }
}
