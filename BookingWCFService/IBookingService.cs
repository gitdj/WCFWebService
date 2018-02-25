using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BookingWCFService
{
    [ServiceContract]
    public interface IBookingService
    {
        [OperationContract]
        BookingResponse BookService(BookingRequest bkReq);
    }

   [DataContract]
    public class BookingRequest
    {
        [DataMember]
        public string BookingType { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Pickup { get; set; }
        [DataMember]
        public string Drop { get; set; }
        [DataMember]
        public string RidingTime { get; set; }
        [DataMember]
        public string Mobile { get; set; }
    }

    [DataContract]
    public class BookingResponse
    {
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string StatusDescription { get; set; }
        [DataMember]
        public string RefNum { get; set; }
    }

}