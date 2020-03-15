using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System_Winform_Model.Service
{
    public class MD5_Service
    {
        private string MD5Encoding1(string data)
        {
            //新增MD5
            MD5 md5 = MD5.Create();
            //將資料轉成BYTE
            byte[] bs = Encoding.UTF8.GetBytes(data);
            //加密
            byte[] hs = md5.ComputeHash(bs);
            StringBuilder stb = new StringBuilder();
            foreach (byte b in hs)
            {
                //byte轉十六進位
                stb.Append(b.ToString("x2"));
            }
            return stb.ToString();
        }

        //加鹽
        public string MD5Encoding2(string data, object salt)
        {
            if (salt == null) return data;
            return MD5Encoding1(data + "{" + salt.ToString() + "}");
        }
    }
}
