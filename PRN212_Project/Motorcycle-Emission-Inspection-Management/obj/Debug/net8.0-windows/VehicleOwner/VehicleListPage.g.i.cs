﻿#pragma checksum "..\..\..\..\VehicleOwner\VehicleListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7351E2BF33CD1BB1B7AD3D564B51C74BB3547238"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Motorcycle_Emission_Inspection_Management.VehicleOwner;
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


namespace Motorcycle_Emission_Inspection_Management.VehicleOwner {
    
    
    /// <summary>
    /// VehicleListPage
    /// </summary>
    public partial class VehicleListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 57 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlateFilter;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtModelFilter;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgVehicles;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Motorcycle-Emission-Inspection-Management;component/vehicleowner/vehiclelistpage" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtPlateFilter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtModelFilter = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgVehicles = ((System.Windows.Controls.DataGrid)(target));
            
            #line 124 "..\..\..\..\VehicleOwner\VehicleListPage.xaml"
            this.dgVehicles.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgVehicles_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

