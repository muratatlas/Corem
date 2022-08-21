using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Corem
{
    public static class Staticlerim
    {
        #region staticlerim 

        public static int kullanicitipistatic = 0;
        public static int tamsayim(this object nesne)
        {
            int sonuc = 0;
            try
            {
                sonuc = Convert.ToInt32(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static bool getbool(this object nesne)
        {
            bool sonuc = false;
            try { sonuc = Convert.ToBoolean(nesne); }

            catch (Exception)
            {
                if (nesne.tamsayim() > 0) sonuc = true;
            }
            return sonuc;
        }
        public static decimal getdeci(this object nesne)
        {
            decimal sonuc = 0;
            try
            {
                sonuc = Convert.ToDecimal(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static double getdouble(this object nesne)
        {
            double sonuc = 0;
            try
            {
                sonuc = Convert.ToDouble(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static float getSingle(this object nesne)
        {
            float sonuc = 0;
            try
            {
                sonuc = Convert.ToSingle(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static List<string> JsonDeserialize(this List<string> nesne)
        {
            List<string> sonuc = null;
            try
            {
                sonuc = JsonConvert.DeserializeObject<List<string>>(nesne.getString());
            }
            catch (Exception) { }
            return sonuc;
        }
        public static string JsonSerialize(this List<string> nesne)
        {
            string sonuc = "";
            try
            {
                sonuc = JsonConvert.SerializeObject(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static string getString(this object nesne)
        {
            string sonuc = "";
            try
            {
                sonuc = Convert.ToString(nesne);
            }
            catch (Exception)
            {

                throw;
            }
            return sonuc;
        }
        public static byte getbyte(this object nesne)
        {
            byte sonuc = 0;
            try
            {
                sonuc = Convert.ToByte(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static DateTime getdate(this object nesne)
        {
            DateTime sonuc = Convert.ToDateTime("18990101");
            try
            {
                sonuc = Convert.ToDateTime(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static char getchar(this object nesne)
        {
            char sonuc = 'â';
            try
            {
                sonuc = Convert.ToChar(nesne);
            }
            catch (Exception) { }
            return sonuc;
        }
        public static void getxmlwriter(this object nesne)
        {

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Save((string)nesne);
            }
            catch (Exception) { }

        }
        public static void getxmlreader(this object nesne)
        {

            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml((string)nesne);

            }
            catch (Exception) { }
        }
        public static string getjsonreader(this object nesne)
        {
            string mylist = "";
            try
            {
                mylist = JsonConvert.DeserializeObject((string)nesne).ToString();



            }
            catch (Exception) { }
            return mylist;
        }
        public static string getjsonwriter(this object nesne)
        {
            string mylist = "";
            try
            {
                mylist = JsonConvert.SerializeObject((string)nesne).ToString();



            }
            catch (Exception) { }
            return mylist;
        }


    }
    #endregion
}
