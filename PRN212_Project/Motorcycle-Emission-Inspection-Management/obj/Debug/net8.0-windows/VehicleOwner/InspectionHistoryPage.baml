   M S B A M L   `   `   `  ����-  )Motorcycle-Emission-Inspection-ManagementR    LMotorcycle_Emission_Inspection_Management.VehicleOwner.InspectionHistoryPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	     � Title$   Lịch sử kiểm định��5   	   $	��500��5   	   $	��900��6    � WindowStartupLocation$ CenterScreen=�5	   	   
�������.��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $ ��Lịch sử kiểm định��6   $��24(�5      $
��Bold"�5      ���#333333$
��Left=�5      $��0 0 0 10q�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgInspectionHistory��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      $��14(�5       $��	0 10 0 10q�5!         Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Biển số xe��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *Vehicle.PlateNumber+6a     5$      $ Cơ sở kiểm định��6%   $ * 6_   	 6>   �� *Station.Name+6_     5%      $ Ngày kiểm định��6%   $ * 6y   	 6=   �� *InspectionDate+
 �� StringFormat$
 
dd/MM/yyyy��6y     5&      $ Kết quả��6%   $ * 6Q   	 66   �� *Result+6Q     5'      $	 CO2��6%   $ * 6R   	 62   �� *Co2emission+6R     5(      $ HC��6%   $ * 6P   	 61   �� *
Hcemission+6P   5*      �� 5-   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5.      �� -   5        $��Thoát��5.      $	��100��5/      $��36��50      $��0 10 0 0q�51      ���#007BFF
�������$
��Bold"�55      $��0q�56       � Cursor$
 Hand��57      58      59      5:      