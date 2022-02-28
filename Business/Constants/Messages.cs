﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
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

        public static string ImageUploaded = "Resim başarıyla yüklendi";
        public static string ImageDeleted = "Resim silindi";
        public static string ImageUpdated = "Resim güncellendi";
        public static string CarImageLimit = "En fazla 5 tane resim yükleyebilirsiniz";

        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string AuthorizationDenied = "Yetkiniz yok!";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kayıt olundu";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş yapıldı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string DeletedRental = "Kira Silindi";

        public static string ListedRentals = "Kiralar Listelendi";

        public static string GettedRental = "Kira Listelendi";

        public static string ReturnOk = "Seçilen Kira Güncellendi";
        public static string UpdatedRental = "Kira güncellendi";

        public static string PaymentAdded = "Ödeme Tamamlandı.";

        public static string LoginSuccessful = "Başarıyla giriş yapıldı.";
        public static string PasswordIsUncorrect = "Parola yanlış.";
        public static string TokenCreated = "Token oluşturuldu.";
        public static string UserAlreadyRegistered = "Kullancı mevcut.";

        public static string CreditCardUpdated = "Kerdi kartı güncellendi";
        public static string CreditCardAdded = "Kredi kartı eklendi";
        public static string CreditCardDeleted = "Kerdi kartı silindi.";

        public static string FindeksAdded = "Findeks puanı eklendi";
        public static string FindeksDeleted = "Findeks puanı silindi";
        public static string FindeksUpdated = "Findeks puanı güncellendi";

        public static string CarHired = "Araba kiralanmış";
        public static string FindeksIsInsufficient = "Findeks puanı yetersiz";
        public static string CarNotReturned = "Araba iade edilemedi";

        public static string CarUpdated = "Araba güncellendi";
    }
}