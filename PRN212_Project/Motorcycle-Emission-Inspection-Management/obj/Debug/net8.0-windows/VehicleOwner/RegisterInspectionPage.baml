   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   - )Motorcycle-Emission-Inspection-ManagementS   MMotorcycle_Emission_Inspection_Management.VehicleOwner.RegisterInspectionPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	     � Title$+  %Đăng ký kiểm định khí thải��5   	   $	��450��5   	   $	��600��6   
������� � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � $��30q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $0��*🛵 Đăng ký kiểm định khí thải��6   $��24(�5      $
��Bold"�6"   ���#333333$��Center=�5      $��0,0,0,20q�5      $��0��6&   �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   $	��Top=�69   .+�5      �� $ 
Horizontal=�6   $��Center=�62   $��0,0,0,40q�6O   .+�5      �� $��Biển số xe:��6   $	��120��5       $��16(�6(   $��Center=�5!      ���#33367   �� 5"      -   5         ��Name$ cbPlateNumbers��5"      $	��250��5#      $��16(�6'   5$      �� 5'      $ 
Horizontal=�6   $��Center=�62   $��0,0,0,40q�6O   .+�5(      �� $��Trạm kiểm định:��6   $	��120��5)      $��16(�6(   $��Center=�5*      ���#33367   �� 5+      -   5        $ 
cbStations��5+      $	��250��5,      $��16(�6'   5-      �� 50      $ 
Horizontal=�6   $��Center=�62   .+�51      �� $��Ngày kiểm định:��6   $	��120��52      $��16(�6(   $��Center=�53      ���#33367   (  "System.Windows.Controls.DatePicker  54      -   5          Name$ dpInspectionDate��54      $	��250��55      $��16(�6)    �� Today   SelectedDate# Z 56         DisplayDateStart# Z 57      58      59      �� 5<   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��0,30,0,0q�6X   .+�5=      �� -   5        $��
Đăng ký��5=      $	��140��5>      $��40��6!   ���#28A745
�������$��16(�5@      $
��Bold"�6#   $��0q�5A      $
��10,0q�5B      5C      �� 5E      -   5        $��Thoát��5E      $	��120��5F      $��40��6!   
����������#007BFF���#007BFF$��16(�5I      $
��Bold"�6#   $��2q�5J      $
��10,0q�5K      5L      5M      5N      5O      