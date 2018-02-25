using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
namespace BookingWCFService
{
    public class BookingService : IBookingService
    {
        public BookingResponse BookService(BookingRequest bkReq)
        {
            return this.Book(bkReq);
        }
        private static Hashtable ht = new Hashtable();
        private BookingResponse Book(BookingRequest bk)
        {
            BookingResponse bkRes = new BookingResponse();
            if (ht.Count < 11)
            {
                if (!ValidateReq(bk))
                {
                    bkRes.Status = "-1";
                    bkRes.StatusDescription = "Basic Info Not Provided";
                    bkRes.RefNum = "-1";
                }
                else
                {
                    if (!ht.Contains(bk.Mobile))
                    {
                        bkRes.RefNum = System.Guid.NewGuid().ToString();
                        bkRes.Status = "1";
                        bkRes.StatusDescription = "Booking Successful";
                        ht.Add(bk.Mobile, bkRes.RefNum);
                    }
                    else
                    {
                        bkRes.Status = "-2";
                        bkRes.StatusDescription = "Already Passenger Has Booked the service";
                    }
                }
            }
            else
            {
                bkRes.Status = "-2";
                bkRes.StatusDescription = "Service Not Available";
                bkRes.RefNum = "-1";
                ht.Clear();
            }
            return bkRes;
        }
        private bool ValidateReq(BookingRequest bk)
        {
            if (bk.BookingType != "" && (bk.BookingType == "Cab" || bk.BookingType == "Auto" || bk.BookingType == "Bike") && bk.Mobile.Length == 10)
            {
                return true;
            }
            return false;
        }
    }
}

