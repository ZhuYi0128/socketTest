﻿#pragma checksum "..\..\..\IPAddressModify.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D674F2E515387E01A58141AD142FD753"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using socketTest.CInput;


namespace socketTest {
    
    
    /// <summary>
    /// IPAddressModify
    /// </summary>
    public partial class IPAddressModify : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cavInfo;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectangle1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal socketTest.CInput.NetIPControl txtNewMaskedIPAddress;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModifyFirewallIPInfo;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\IPAddressModify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClearFirewallIPInfo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/socketTest;component/ipaddressmodify.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\IPAddressModify.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cavInfo = ((System.Windows.Controls.Canvas)(target));
            
            #line 13 "..\..\..\IPAddressModify.xaml"
            this.cavInfo.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cavInfo_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rectangle1 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtNewMaskedIPAddress = ((socketTest.CInput.NetIPControl)(target));
            return;
            case 5:
            this.canvas2 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.btnModifyFirewallIPInfo = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\IPAddressModify.xaml"
            this.btnModifyFirewallIPInfo.Click += new System.Windows.RoutedEventHandler(this.btnModifyFirewallIPInfo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\IPAddressModify.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnClearFirewallIPInfo = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\IPAddressModify.xaml"
            this.btnClearFirewallIPInfo.Click += new System.Windows.RoutedEventHandler(this.btnClearFirewallIPInfo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
