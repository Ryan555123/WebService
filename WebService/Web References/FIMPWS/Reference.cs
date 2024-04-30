﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.42000。
// 
#pragma warning disable 1591

namespace WebService.FIMPWS {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SFIS_WSSoap", Namespace="http://tempuri.org/")]
    public partial class SFIS_WS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RvOperationCompleted;
        
        private System.Threading.SendOrPostCallback TxOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetServerTimeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSapConnectionStringOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SFIS_WS() {
            this.Url = global::WebService.Properties.Settings.Default.WebService_FIMPWS_SFIS_WS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event RvCompletedEventHandler RvCompleted;
        
        /// <remarks/>
        public event TxCompletedEventHandler TxCompleted;
        
        /// <remarks/>
        public event GetServerTimeCompletedEventHandler GetServerTimeCompleted;
        
        /// <remarks/>
        public event GetSapConnectionStringCompletedEventHandler GetSapConnectionStringCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Rv", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet Rv(string sParam) {
            object[] results = this.Invoke("Rv", new object[] {
                        sParam});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RvAsync(string sParam) {
            this.RvAsync(sParam, null);
        }
        
        /// <remarks/>
        public void RvAsync(string sParam, object userState) {
            if ((this.RvOperationCompleted == null)) {
                this.RvOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRvOperationCompleted);
            }
            this.InvokeAsync("Rv", new object[] {
                        sParam}, this.RvOperationCompleted, userState);
        }
        
        private void OnRvOperationCompleted(object arg) {
            if ((this.RvCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RvCompleted(this, new RvCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Tx", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Tx(string sParam, string sType) {
            object[] results = this.Invoke("Tx", new object[] {
                        sParam,
                        sType});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TxAsync(string sParam, string sType) {
            this.TxAsync(sParam, sType, null);
        }
        
        /// <remarks/>
        public void TxAsync(string sParam, string sType, object userState) {
            if ((this.TxOperationCompleted == null)) {
                this.TxOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTxOperationCompleted);
            }
            this.InvokeAsync("Tx", new object[] {
                        sParam,
                        sType}, this.TxOperationCompleted, userState);
        }
        
        private void OnTxOperationCompleted(object arg) {
            if ((this.TxCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TxCompleted(this, new TxCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetServerTime", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.DateTime GetServerTime() {
            object[] results = this.Invoke("GetServerTime", new object[0]);
            return ((System.DateTime)(results[0]));
        }
        
        /// <remarks/>
        public void GetServerTimeAsync() {
            this.GetServerTimeAsync(null);
        }
        
        /// <remarks/>
        public void GetServerTimeAsync(object userState) {
            if ((this.GetServerTimeOperationCompleted == null)) {
                this.GetServerTimeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetServerTimeOperationCompleted);
            }
            this.InvokeAsync("GetServerTime", new object[0], this.GetServerTimeOperationCompleted, userState);
        }
        
        private void OnGetServerTimeOperationCompleted(object arg) {
            if ((this.GetServerTimeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetServerTimeCompleted(this, new GetServerTimeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSapConnectionString", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetSapConnectionString() {
            object[] results = this.Invoke("GetSapConnectionString", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetSapConnectionStringAsync() {
            this.GetSapConnectionStringAsync(null);
        }
        
        /// <remarks/>
        public void GetSapConnectionStringAsync(object userState) {
            if ((this.GetSapConnectionStringOperationCompleted == null)) {
                this.GetSapConnectionStringOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSapConnectionStringOperationCompleted);
            }
            this.InvokeAsync("GetSapConnectionString", new object[0], this.GetSapConnectionStringOperationCompleted, userState);
        }
        
        private void OnGetSapConnectionStringOperationCompleted(object arg) {
            if ((this.GetSapConnectionStringCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSapConnectionStringCompleted(this, new GetSapConnectionStringCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void RvCompletedEventHandler(object sender, RvCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RvCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RvCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void TxCompletedEventHandler(object sender, TxCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TxCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TxCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void GetServerTimeCompletedEventHandler(object sender, GetServerTimeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetServerTimeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetServerTimeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.DateTime Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.DateTime)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void GetSapConnectionStringCompletedEventHandler(object sender, GetSapConnectionStringCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSapConnectionStringCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSapConnectionStringCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591