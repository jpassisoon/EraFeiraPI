using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography; // biblioteca importada a criptografia
using System.Text; // biblioteca importada para criar a criptografia
using System.Web;

namespace EraFeira.Models
{
    public class Criptografia
    {

        public static string Encrypt(string valor)
        {
            var str = "";
            try
            {
                UnicodeEncoding ue = new UnicodeEncoding();
                byte[] hashByte, mensagemByte = ue.GetBytes(valor);
                SHA512Managed sha = new SHA512Managed();
                hashByte = sha.ComputeHash(mensagemByte);
                foreach (byte x in hashByte)
                {
                    str += String.Format("{0:x2}", x);
                    //return str.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return str;

        }

    }
}