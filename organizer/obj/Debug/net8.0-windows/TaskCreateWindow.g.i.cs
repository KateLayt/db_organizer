﻿#pragma checksum "..\..\..\TaskCreateWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0888CAE686D31109133C2317407101BB26407E61"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using organizer;


namespace organizer {
    
    
    /// <summary>
    /// TaskCreateWindow
    /// </summary>
    public partial class TaskCreateWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_TaskName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Pnl_TaskType;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Rb_Plain;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Rb_Repeatable;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Rb_Deadlined;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Pnl_Deadline;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date_Deadline;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Pnl_LastDone;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date_LastDone;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Pnl_RepeatEvery;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\TaskCreateWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_RepeatEvery;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/organizer;component/taskcreatewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TaskCreateWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Txt_TaskName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Pnl_TaskType = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.Rb_Plain = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\TaskCreateWindow.xaml"
            this.Rb_Plain.Checked += new System.Windows.RoutedEventHandler(this.Rb_Plain_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Rb_Repeatable = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\TaskCreateWindow.xaml"
            this.Rb_Repeatable.Checked += new System.Windows.RoutedEventHandler(this.Rb_Repeatable_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Rb_Deadlined = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\..\TaskCreateWindow.xaml"
            this.Rb_Deadlined.Checked += new System.Windows.RoutedEventHandler(this.Rb_Deadlined_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Pnl_Deadline = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.Date_Deadline = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.Pnl_LastDone = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.Date_LastDone = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.Pnl_RepeatEvery = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 11:
            this.Txt_RepeatEvery = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\TaskCreateWindow.xaml"
            this.Txt_RepeatEvery.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 35 "..\..\..\TaskCreateWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 36 "..\..\..\TaskCreateWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Btn_Create_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

