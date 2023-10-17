using Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extention
{
    public static class StringExtention
    {
        public static string MaskPhoneNumber(this string phoneNumber)
        {
            if (phoneNumber.Length != 11)
                throw new BusinessLogicException("شماره تلفن معتبر نیست");

            var maskedPhoneNumber = phoneNumber.Substring(0, 4) + "***" + phoneNumber.Substring(7, 4);
            return maskedPhoneNumber;
        }
        public static string ToBase64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string GetSHA256Hash(this string input)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(input);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(dataBytes);
                string checksum = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return checksum;
            }
        }

        public static DateTime ToDateTime(this string dateTime)
        {
            //Correct Format For Data is Like it
            //1398-05-06 14:45
            var splited = dateTime.Split("-");
            var year = int.Parse(splited[0]);
            var month = int.Parse(splited[1]);

            var dayAndTime = splited[2].Split(" ");
            var day = int.Parse(dayAndTime[0]);
            var time = dayAndTime[1].Split(":");

            var hour = int.Parse(time[0]);
            var minute = int.Parse(time[1]);

            var persianCalender = new PersianCalendar();
            var result = persianCalender.ToDateTime(year, month, day, hour, minute,0,0);
           
            return result;


        }



    }
}
