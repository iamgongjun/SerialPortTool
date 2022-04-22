using System;
using System.Text;

namespace SerialPortTool.API
{
    public static class Extensions
    {
        /// <summary>
        /// 16进制转byte[]
        /// </summary>
        /// <param name="hs"></param>
        /// <returns></returns>
        public static byte[] HexStringToBytes(this string hs)
        {
            string[] strArr = hs.Trim().Split(' ');
            byte[] b = new byte[strArr.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < strArr.Length; i++)
            {
                b[i] = Convert.ToByte(strArr[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return b;
        }
        /// <summary>
        /// string转16进制
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        public static string StringToHexString(this string s, Encoding encode)
        {
            byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            {
                result += b[i].ToString("x2") + " ";
            }
            //for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符
            //{
            //    result+=(Convert.ToString(b[i], 16).Length < 2 ? 
            //        "0" + Convert.ToString(b[i], 16) : Convert.ToString(b[i], 16))+" ";
            //}
            return result;
        }
        public static string StringToHexString(this byte[] receiveData)
        {
            //byte[] b = encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result = string.Empty;
            for (int i = 0; i < receiveData.Length; i++)//逐字节变为16进制字符
            {
                result += (Convert.ToString(receiveData[i], 16).Length < 2 ?
                    "0" + Convert.ToString(receiveData[i], 16) : Convert.ToString(receiveData[i], 16)) + " ";
            }
            return result;
        }
    }
}
