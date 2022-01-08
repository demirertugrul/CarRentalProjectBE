using Entities.Concrete;
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
        public static string BrandUpdated = "Araba güncellendi";

        public static string ServerNotWorking = "Server Bakımda..";

        public static string ColorUpdate = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorsListed = "Renkler Listelendi";

        public static string RentalAdded = "Yeni Araba Kira eklendi";
        public static string GetRentals = "Kiralanan arabalar listelendi";

        public static string BrandIdsListed = "İstenilen id'ye sahip markalar listelendi";
        public static string BrandListed = "İstenilen id'ye sahip marka listelendi";
        public static string BrandsListed = "Tüm Markalar listelendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandAdded = "Marka Eklendi";

        public static string GTModelYear = "Araba Modeli 1886'dan büyük olmalıdır!";
    }
}