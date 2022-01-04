using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constrants
{
    public static class Messages
    {
        public static string CarAdded = "Yeni Araba Eklendi";

        public static string CarNotAdded = "Araba ismi 2 karakterden uzun olmalıdır ve fiyatı 0 dan büyük olmalıdır";

        public static string CarDeleted = "Araba Silindi";

        public static string CarListed = "Seçilen Araba Listelendi";

        public static string CarsAllListed = "Arabalar Listelendi";

        public static string CarDetailGot = "Araba Detayları Listelendi";

        public static string CarUpdated = "Araba güncellendi";
        public static string GetRental = "Kiralanan araba listelendi";
        public static string ServerNotWorking = "Server Bakımda..";
    }
}