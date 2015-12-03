﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.NC_Services {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchCriminalModel", Namespace="http://schemas.datacontract.org/2004/07/WebApplication.Services")]
    [System.SerializableAttribute()]
    public partial class SearchCriminalModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MaxAgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> MaxHeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<float> MaxWeigthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> MinAgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<double> MinHeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<float> MinWeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NationalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MaxAge {
            get {
                return this.MaxAgeField;
            }
            set {
                if ((this.MaxAgeField.Equals(value) != true)) {
                    this.MaxAgeField = value;
                    this.RaisePropertyChanged("MaxAge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> MaxHeight {
            get {
                return this.MaxHeightField;
            }
            set {
                if ((this.MaxHeightField.Equals(value) != true)) {
                    this.MaxHeightField = value;
                    this.RaisePropertyChanged("MaxHeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<float> MaxWeigth {
            get {
                return this.MaxWeigthField;
            }
            set {
                if ((this.MaxWeigthField.Equals(value) != true)) {
                    this.MaxWeigthField = value;
                    this.RaisePropertyChanged("MaxWeigth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> MinAge {
            get {
                return this.MinAgeField;
            }
            set {
                if ((this.MinAgeField.Equals(value) != true)) {
                    this.MinAgeField = value;
                    this.RaisePropertyChanged("MinAge");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<double> MinHeight {
            get {
                return this.MinHeightField;
            }
            set {
                if ((this.MinHeightField.Equals(value) != true)) {
                    this.MinHeightField = value;
                    this.RaisePropertyChanged("MinHeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<float> MinWeight {
            get {
                return this.MinWeightField;
            }
            set {
                if ((this.MinWeightField.Equals(value) != true)) {
                    this.MinWeightField = value;
                    this.RaisePropertyChanged("MinWeight");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nationality {
            get {
                return this.NationalityField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalityField, value) != true)) {
                    this.NationalityField = value;
                    this.RaisePropertyChanged("Nationality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sex {
            get {
                return this.SexField;
            }
            set {
                if ((object.ReferenceEquals(this.SexField, value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NC_Services.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DoWork", ReplyAction="http://tempuri.org/IService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/DoWork", ReplyAction="http://tempuri.org/IService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SearchCriminal", ReplyAction="http://tempuri.org/IService/SearchCriminalResponse")]
        bool SearchCriminal(WebApplication.NC_Services.SearchCriminalModel objModel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/SearchCriminal", ReplyAction="http://tempuri.org/IService/SearchCriminalResponse")]
        System.Threading.Tasks.Task<bool> SearchCriminalAsync(WebApplication.NC_Services.SearchCriminalModel objModel);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : WebApplication.NC_Services.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<WebApplication.NC_Services.IService>, WebApplication.NC_Services.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public bool SearchCriminal(WebApplication.NC_Services.SearchCriminalModel objModel) {
            return base.Channel.SearchCriminal(objModel);
        }
        
        public System.Threading.Tasks.Task<bool> SearchCriminalAsync(WebApplication.NC_Services.SearchCriminalModel objModel) {
            return base.Channel.SearchCriminalAsync(objModel);
        }
    }
}