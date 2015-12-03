using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        bool SearchCriminal(SearchCriminalModel objModel);
    }

    [DataContract]
    public class SearchCriminalModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? MinAge { get; set; }
        [DataMember]
        public int? MaxAge { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public double? MinHeight { get; set; }
        [DataMember]
        public double? MaxHeight { get; set; }
        [DataMember]
        public float? MinWeight { get; set; }
        [DataMember]
        public float? MaxWeigth { get; set; }
        [DataMember]
        public string Nationality { get; set; }

    }
}
