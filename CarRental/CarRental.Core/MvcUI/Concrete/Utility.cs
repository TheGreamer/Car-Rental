using System;
using System.IO;
using System.Web;

namespace CarRental.Core.MvcUI.Concrete
{
    public class Utility
    {
        public static string RedirectWithMessage(string message, string controller = "Home", string action = "Index", bool useAlertifyJs = true, double duration = 2.5, MessageType messageType = MessageType.alert)
        {
            return useAlertifyJs ? "<head>" +
                                       "<link rel='stylesheet' href='/Content/css/alertify.min.css' />" +
                                       "<link rel='stylesheet' href='/Content/css/bootstrap.rtl.min.css' />" +
                                       "<script src='/Content/js/alertify.min.js'></script>" +
                                   "</head>" +
                                   $"<body style='background-color: #{new Random().Next(0x1000000):X6}'>" +
                                       "<script> function sleep (time) { return new Promise((resolve) => setTimeout(resolve, time)); }</script>" +
                                       $"<script> alertify.{messageType}('{message}'); sleep({duration * 1000}).then(() => " + "{" + $"window.location.href = '/{controller}/{action}'" + "}); </script>" +
                                   "</body>"

                                 : $"<script> alert('{message}'); window.location.href = '/{controller}/{action}'; </script>";
        }

        public static string Translate(string word)
        {
            string translation = string.Empty;

            switch (word)
            {
                case "Blog": translation = "Blog"; break;
                case "Car": translation = "Araba"; break;
                case "CarImage": translation = "Araç resmi"; break;
                case "Comment": translation = "Yorum"; break;
                case "Coordinate": translation = "Koordinat"; break;
                case "CustomerReview": translation = "Müşteri değerlendirmesi"; break;
                case "Device": translation = "Cihaz"; break;
                case "Driver": translation = "Şoför"; break;
                case "Faq": translation = "Sıkça sorulan soru"; break;
                case "IotCar": translation = "Iot araç"; break;
                case "Message": translation = "Mesaj"; break;
                case "Partner": translation = "Ortak"; break;
                case "PricingPlan": translation = "Ödeme yöntemi"; break;
                case "Shipment": translation = "Sevkiyat"; break;
                case "TeamMember": translation = "Takım üyesi"; break;
            }

            return translation;
        }

        public static string SaveFile(HttpPostedFileBase file, string folderPath)
        {
            string fileName = $"{Guid.NewGuid()}-{file.FileName}";
            file.SaveAs(Path.Combine(folderPath, fileName));
            return fileName;
        }
    }

    public enum MessageType { alert, success, error }
}