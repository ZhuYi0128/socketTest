﻿#pragma checksum "..\..\..\NamePwd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5480135235D94935595A25C5ABB26C5"
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


namespace socketTest {
    
    
    /// <summary>
    /// NamePwd
    /// </summary>
    public partial class NamePwd : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas cavInfo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModifyUserLoadInfo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtOldUserName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNewUserName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtOldUserPassword;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtNewUserPassword;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\NamePwd.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtReenterUserPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/socketTest;component/namepwd.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NamePwd.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 11 "..\..\..\NamePwd.xaml"
            this.cavInfo.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cavInfo_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnModifyUserLoadInfo = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\NamePwd.xaml"
            this.btnModifyUserLoadInfo.Click += new System.Windows.RoutedEventHandler(this.btnModifyUserLoadInfo_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtOldUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\NamePwd.xaml"
            this.txtOldUserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtOldUserName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtNewUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\NamePwd.xaml"
            this.txtNewUserName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtNewUserName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtOldUserPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.txtNewUserPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.txtReenterUserPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
