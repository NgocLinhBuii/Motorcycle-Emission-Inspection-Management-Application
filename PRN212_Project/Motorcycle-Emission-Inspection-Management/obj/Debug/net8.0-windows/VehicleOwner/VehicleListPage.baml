   M S B A M L   `   `   `  ����-  )Motorcycle-Emission-Inspection-ManagementL    FMotorcycle_Emission_Inspection_Management.VehicleOwner.VehicleListPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   Danh sách phương tiện��5   	   $	��500��5   	   $	��900��6    � WindowStartupLocation$ CenterScreen=�5   	   
�������.��5	      � $��20,20,20,48q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $#��Danh sách xe đã đăng ký��6   $��24(�5      $
��Bold"�6"   ���#333333$
��Left=�5      $��
520,2,0,13q�5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��	0,10,0,10q�6.   $��0��6A   $
��Left=�6N   .+�5      �� $��0 0 20 0q�6   .+�5      �� $��Biển số��6   $��14(�6+   ���#33369   �� 5      -   5         ��Name$ txtPlateFilter��5      $	��150��62   5      �� 5      $��0 0 20 0q�6   .+�5      �� $��Model��6   $��14(�6)   ���#33367   �� 5      -   5        $ txtModelFilter��5      $	��150��62   5       �� 5!      -   5         ��Name$ 	btnSearch��5!      $��Tìm kiếm��5"      $	��100��5#      $��36��6!   ���#007BFF
�������$��16(�5&      $
��Bold"�5'      6'   5)      &   System.Windows.Controls.DataGrid  5,   
   -   5          Name$ 
dgVehicles��5,      $��1��5-         AutoGenerateColumns$ False��5.         
IsReadOnly$
 True��5/      $��14(�50      $��0,10,0,0q�51      $	��357��6T   $	��Top=�6a   	   Columns	 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Biển số��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *PlateNumber+6V     54      $
 Hãng��6%   $ * 6M    63   �� *Brand+6M     55      $
 Dòng xe��6%   $ * 6P    66   �� *Model+6P     56      $
 Năm SX��6%   $ * 6Y    65   �� *ManufactureYear+6Y     57      $
 	Số máy��6%   $ * 6V    65   �� *EngineNumber+6V   59      �� 5:   
   -   5        $ btnQuit��5:      $��Thoát��5;      $	��100��5<      $��36��6   
����������#007BFF$��2q�5?      ���#007BFF$��16(�5A      $��750,10,10,-36q�5B   #   $��2��6:   �� 5E   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0 10 0 0q�6W   5F      5G      