using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;
using Kavenegar.Exceptions;

namespace Common.Library
{
    public class SendMessage
    {
        public static KavenegarApi Api;
        public static void SendSMS( string receptor, string token,string token2 , string token3,string template)
        {
            Api = new KavenegarApi("326C4D6F466E46637061714A747930487875702B3072737671766C7045572F4E4345306456574D713953633D");

                 receptor = "";
                 token = "";
                 token2 = "";
                 token3 = "";
                 template = "";
                var result = Api.VerifyLookup(receptor, token, token2, token3, template);
                //if (result != null)
                //{
                //    Console.WriteLine(result.Cost + "\n");
                //    Console.WriteLine(result.Date + "\n");
                //    Console.WriteLine(result.Message + "\n");
                //    Console.WriteLine(result.Receptor + "\n");
                //    Console.WriteLine(result.Sender + "\n");
                //    Console.WriteLine(result.Status + "\n");
                //    Console.WriteLine(result.StatusText + "\n");
                //}
            //}
            //catch (ApiException ex)
            //{
            //    // در صورتی که خروجی وب سرویس 200 نباشد این خطارخ می دهد.
            //    Console.Write("Message : " + ex.Message);
            //}
            //catch (HttpException ex)
            //{
            //    // در زمانی که مشکلی در برقرای ارتباط با وب سرویس وجود داشته باشد این خطا رخ می دهد
            //    Console.Write("Message : " + ex.Message);
            //}
        }
    }
}
