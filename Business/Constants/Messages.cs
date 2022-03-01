using Core.Entities.Concrete;
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
        public static string CarAdded = "New Car Added.";
        public static string CarNotAdded = "Car name must be longer than 2 characters and price must be greater than 0.";
        public static string CarDeleted = "Car Deleted.";
        public static string CarListed = "Selected Car Listed.";
        public static string CarsAllListed = "Cars Listed.";
        public static string CarDetailGot = "Car Details Listed.";
        public static string CarUpdated = "The car has been updated.";
        public static string CarHired = "You rented the Car.";
        public static string CarNotReturned = "The car could not be returned.";

        public static string ServerNotWorking = "Server is in maintenance..";

        public static string ColorUpdate = "Color updated.";
        public static string ColorDeleted = "Color removed.";
        public static string ColorAdded = "Color added.";
        public static string ColorsListed = "Colors Listed.";

        public static string RentalAdded = "New Car Rental added.";
        public static string GetRentals = "Rented vehicles listed.";
        public static string DeletedRental = "Rent Deleted.";
        public static string ListedRentals = "Rents Listed.";
        public static string GettedRental = "Rent Listed.";
        public static string ReturnOk = "Selected Rent Updated.";

        public static string BrandIdsListed = "The brands with the desired id are listed.";
        public static string BrandListed = "The brand with the desired id is listed.";
        public static string BrandsListed = "All Brands listed.";
        public static string BrandDeleted = "Brand deleted.";
        public static string BrandAdded = "Brand Added.";
        public static string BrandUpdated = "The car has been updated.";

        public static string GTModelYear = "Car Model must be greater than 1886!";

        public static string ImageUploaded = "Image uploaded successfully.";
        public static string ImageDeleted = "Image deleted.";
        public static string ImageUpdated = "Image updated.";
        public static string CarImageLimit = "You can upload maximum 5 image.";

        public static string UserUpdated = "User updated.";
        public static string UserDeleted = "User deleted.";
        public static string UserAdded = "User added.";
        public static string UserNotFound = "User not found!.";
        public static string UserRegistered = "User registered.";

        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Login succesful!.";
        public static string AuthorizationDenied = "Authorization Denied!.";
        public static string AccessTokenCreated = "Token created!";
        public static string UserAlreadyExists = "User is already exists!.";
        public static string UserAlreadyRegistered = "User is already registered!.";
        public static string TokenCreated = "Token Created!.";
        public static string PasswordIsUncorrect = "Password is incorrect!.";
        public static string LoginSuccessful = "Login Successful.";

        public static string PaymentAdded = "Payment succesful!.";

        public static string CreditCardUpdated = "Credit Card updated.";
        public static string CreditCardAdded = "Credit Card added.";
        public static string CreditCardDeleted = "Credit Card deleted.";

        public static string FindeksAdded = "Findeks point added.";
        public static string FindeksDeleted = "Findeks point deleted.";
        public static string FindeksUpdated = "Findeks point updated.";
        public static string FindeksIsInsufficient = "Findeks point not enough!.";


    }
}