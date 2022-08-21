using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Forms;

namespace Corem
{
    public class Method
    {
        #region mailgonder
        public void MailGonder(string gonderen, string gidecek, string cc, string gidecek_bcc, string gonderilceklerpath, string konu, string icerik, string gonderenmailbilgisi, string gonderensifre, string gonderenmailsunucu, int gonderenportu, bool sslmi, bool tekthread)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(gonderen);
            string[] toadd = gidecek.Split(';');
            foreach (var item in toadd)
            {
                if (item == "")
                {
                    continue;
                }
                email.To.Add(item);
            }
            string[] ccadd = cc.Split(';');
            foreach (var item in ccadd)
            {
                email.CC.Add(item);
            }
            string[] bccadd = gidecek_bcc.Split(';');
            foreach (var item in ccadd)
            {
                email.Bcc.Add(item);
            }
            string[] atachadd = gonderilceklerpath.Split(';');
            foreach (var item in atachadd)
            {
                email.Attachments.Add(new Attachment(item));
            }
            email.Subject = konu;
            email.Body = icerik;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new System.Net.NetworkCredential(gonderenmailbilgisi, gonderensifre);
            smtp.Port = gonderenportu;
            smtp.Host = gonderenmailsunucu;
            smtp.EnableSsl = sslmi;
            try
            {
                if (tekthread == true)
                {
                    smtp.SendAsync(email, (object)email);
                }
                else
                {
                    smtp.Send(email);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.getString());
            }
        }
        #endregion
        #region QR alanı
        public Bitmap QrOlustur(string metin)
        {
            QRCodeEncoder enc = new QRCodeEncoder();
            Bitmap qrcode = enc.Encode(metin);
            return qrcode;
        }

        public string QrOku(Bitmap resim)
        {
            string metin = "";
            QRCodeDecoder dec = new QRCodeDecoder();
            metin = (dec.Decode(new QRCodeBitmapImage(resim)));
            return metin;
        }
        #endregion
        #region kurlar
        public void kurlar(WebBrowser browse)
        {
            //XmlDocument xmlVerisi = new XmlDocument();
            //xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
            browse.Navigate("\"https://www.tcmb.gov.tr/kurlar/today.xml");
            browse.ScriptErrorsSuppressed = true;

        }
        #endregion
        #region processrun
        public void ProcessStart(string metin)
        {
            System.Diagnostics.Process.Start(metin);
        }
        #endregion
        //#region gridtopdf
        //public void gridtopdf (Gridcontrol data,string  path)
        //{

        //}
        //#endregion
        //#region gridtoxls
        //public void gridtoxls (Gridcontrol data,string  path)
        //{

        //}
        //#endregion
    }
}
