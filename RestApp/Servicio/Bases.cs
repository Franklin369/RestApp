using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RestApp.Servicio
{
    public class Bases
    {
        public static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public static MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        public static string appPwdUnique = "RESTAURAnTE.codigo369.BUMAM.Hola_Mundo";
        public static string Encriptar(string texto)
        {
            string tempEncriptar = null;
            if (string.IsNullOrEmpty(texto.Trim(' ')))
            {
                tempEncriptar = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(appPwdUnique));
                des.Mode = CipherMode.ECB;
                ICryptoTransform encrypt = des.CreateEncryptor();
                byte[] buff = UnicodeEncoding.ASCII.GetBytes(texto);
                tempEncriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            return tempEncriptar;
        }
        public static string Desencriptar(string texto)
        {
            string tempDesencriptar = null;
            if (string.IsNullOrEmpty(texto.Trim(' ')))
            {
                tempDesencriptar = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(appPwdUnique));
                des.Mode = CipherMode.ECB;
                ICryptoTransform desencrypta = des.CreateDecryptor();
                byte[] buff = Convert.FromBase64String(texto);
                tempDesencriptar = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length));
            }
            return tempDesencriptar;
        }
    }
}
