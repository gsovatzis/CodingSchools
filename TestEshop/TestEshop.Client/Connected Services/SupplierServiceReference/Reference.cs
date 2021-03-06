﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestEshop.Client.SupplierServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SupplierServiceReference.ISupplierService")]
    public interface ISupplierService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/GetAllSuppliers", ReplyAction="http://tempuri.org/ISupplierService/GetAllSuppliersResponse")]
        System.Collections.Generic.List<TestEshop.Models.Supplier> GetAllSuppliers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/GetAllSuppliers", ReplyAction="http://tempuri.org/ISupplierService/GetAllSuppliersResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<TestEshop.Models.Supplier>> GetAllSuppliersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/GetSupplier", ReplyAction="http://tempuri.org/ISupplierService/GetSupplierResponse")]
        TestEshop.Models.Supplier GetSupplier(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/GetSupplier", ReplyAction="http://tempuri.org/ISupplierService/GetSupplierResponse")]
        System.Threading.Tasks.Task<TestEshop.Models.Supplier> GetSupplierAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/InsertSupplier", ReplyAction="http://tempuri.org/ISupplierService/InsertSupplierResponse")]
        void InsertSupplier(TestEshop.Models.Supplier p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/InsertSupplier", ReplyAction="http://tempuri.org/ISupplierService/InsertSupplierResponse")]
        System.Threading.Tasks.Task InsertSupplierAsync(TestEshop.Models.Supplier p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/DeleteSupplier", ReplyAction="http://tempuri.org/ISupplierService/DeleteSupplierResponse")]
        void DeleteSupplier(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/DeleteSupplier", ReplyAction="http://tempuri.org/ISupplierService/DeleteSupplierResponse")]
        System.Threading.Tasks.Task DeleteSupplierAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/UpdateSupplier", ReplyAction="http://tempuri.org/ISupplierService/UpdateSupplierResponse")]
        void UpdateSupplier(TestEshop.Models.Supplier p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISupplierService/UpdateSupplier", ReplyAction="http://tempuri.org/ISupplierService/UpdateSupplierResponse")]
        System.Threading.Tasks.Task UpdateSupplierAsync(TestEshop.Models.Supplier p);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISupplierServiceChannel : TestEshop.Client.SupplierServiceReference.ISupplierService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SupplierServiceClient : System.ServiceModel.ClientBase<TestEshop.Client.SupplierServiceReference.ISupplierService>, TestEshop.Client.SupplierServiceReference.ISupplierService {
        
        public SupplierServiceClient() {
        }
        
        public SupplierServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SupplierServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SupplierServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SupplierServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<TestEshop.Models.Supplier> GetAllSuppliers() {
            return base.Channel.GetAllSuppliers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<TestEshop.Models.Supplier>> GetAllSuppliersAsync() {
            return base.Channel.GetAllSuppliersAsync();
        }
        
        public TestEshop.Models.Supplier GetSupplier(int Id) {
            return base.Channel.GetSupplier(Id);
        }
        
        public System.Threading.Tasks.Task<TestEshop.Models.Supplier> GetSupplierAsync(int Id) {
            return base.Channel.GetSupplierAsync(Id);
        }
        
        public void InsertSupplier(TestEshop.Models.Supplier p) {
            base.Channel.InsertSupplier(p);
        }
        
        public System.Threading.Tasks.Task InsertSupplierAsync(TestEshop.Models.Supplier p) {
            return base.Channel.InsertSupplierAsync(p);
        }
        
        public void DeleteSupplier(int Id) {
            base.Channel.DeleteSupplier(Id);
        }
        
        public System.Threading.Tasks.Task DeleteSupplierAsync(int Id) {
            return base.Channel.DeleteSupplierAsync(Id);
        }
        
        public void UpdateSupplier(TestEshop.Models.Supplier p) {
            base.Channel.UpdateSupplier(p);
        }
        
        public System.Threading.Tasks.Task UpdateSupplierAsync(TestEshop.Models.Supplier p) {
            return base.Channel.UpdateSupplierAsync(p);
        }
    }
}
