﻿#pragma checksum "..\..\reg.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1DB75E046366A8F56E72A9C9E4430C4A38D61A10999C5AA834B6C4EEFC339C5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp2;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace WpfApp2 {
    
    
    /// <summary>
    /// dva
    /// </summary>
    public partial class dva : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LogTB;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox ParTB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Fio;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Pass;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateR;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DateP;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Adr;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\reg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tel;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp2;component/reg.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\reg.xaml"
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
            
            #line 18 "..\..\reg.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LogTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\reg.xaml"
            this.LogTB.GotFocus += new System.Windows.RoutedEventHandler(this.LogTB_GotFocus);
            
            #line default
            #line hidden
            
            #line 21 "..\..\reg.xaml"
            this.LogTB.LostFocus += new System.Windows.RoutedEventHandler(this.LogTB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ParTB = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 22 "..\..\reg.xaml"
            this.ParTB.LostFocus += new System.Windows.RoutedEventHandler(this.ParTB_LostFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Fio = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\reg.xaml"
            this.Fio.GotFocus += new System.Windows.RoutedEventHandler(this.NameTB_GotFocus);
            
            #line default
            #line hidden
            
            #line 24 "..\..\reg.xaml"
            this.Fio.LostFocus += new System.Windows.RoutedEventHandler(this.NameTB_LostFocus_1);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 25 "..\..\reg.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Pass = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\reg.xaml"
            this.Pass.GotFocus += new System.Windows.RoutedEventHandler(this.Pass_GotFocus);
            
            #line default
            #line hidden
            
            #line 26 "..\..\reg.xaml"
            this.Pass.LostFocus += new System.Windows.RoutedEventHandler(this.Pass_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DateR = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\reg.xaml"
            this.DateR.GotFocus += new System.Windows.RoutedEventHandler(this.DateR_GotFocus);
            
            #line default
            #line hidden
            
            #line 31 "..\..\reg.xaml"
            this.DateR.LostFocus += new System.Windows.RoutedEventHandler(this.DateR_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DateP = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\reg.xaml"
            this.DateP.GotFocus += new System.Windows.RoutedEventHandler(this.DateP_GotFocus);
            
            #line default
            #line hidden
            
            #line 32 "..\..\reg.xaml"
            this.DateP.LostFocus += new System.Windows.RoutedEventHandler(this.DateP_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Adr = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\reg.xaml"
            this.Adr.GotFocus += new System.Windows.RoutedEventHandler(this.Adr_GotFocus);
            
            #line default
            #line hidden
            
            #line 33 "..\..\reg.xaml"
            this.Adr.LostFocus += new System.Windows.RoutedEventHandler(this.Adr_LostFocus);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Tel = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\reg.xaml"
            this.Tel.GotFocus += new System.Windows.RoutedEventHandler(this.Tel_GotFocus);
            
            #line default
            #line hidden
            
            #line 34 "..\..\reg.xaml"
            this.Tel.LostFocus += new System.Windows.RoutedEventHandler(this.Tel_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

