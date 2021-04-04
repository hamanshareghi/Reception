using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kavenegar;
using Kavenegar.Models;
using Kavenegar.Models.Enums;

namespace Common.Library
{
    public class SendMessage
    {

        public static void SendReception( string receptor, string token,string token2 , string token3,string template)
        {


            #region VerifyLookupAsync

            KavenegarApi kavenegar = new KavenegarApi("326C4D6F466E46637061714A747930487875702B3072737671766C7045572F4E4345306456574D713953633D");

            SendResult result = null;

            result = kavenegar.VerifyLookup(receptor, token, token2, token3, template, VerifyLookupType.Sms);
            #endregion

        }
        public static void SendRequestDevice(string receptor, string token, string token2,string token3, string template)
        {


            #region VerifyLookupAsync

            KavenegarApi kavenegar = new KavenegarApi("326C4D6F466E46637061714A747930487875702B3072737671766C7045572F4E4345306456574D713953633D");

            SendResult result = null;

            result = kavenegar.VerifyLookup(receptor, token, token2, null, template, VerifyLookupType.Sms);
            #endregion

        }
    }
}
