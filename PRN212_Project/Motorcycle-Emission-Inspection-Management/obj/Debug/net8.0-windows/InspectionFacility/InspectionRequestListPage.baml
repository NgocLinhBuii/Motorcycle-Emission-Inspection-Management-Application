   M S B A M L   `   `   `  ����-  )Motorcycle-Emission-Inspection-Management\    VMotorcycle_Emission_Inspection_Management.InspectionFacility.InspectionRequestListPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$:  4Danh sách phương tiện đăng ký kiểm định��5   	   $	��600��5   	   $	��900��6   
������� � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0 0 0 15q�6.   .+�5      �� $��0 0 15 0q�6   .+�5      �� $��
Từ ngày��6   $��14(�6+   ���#33333369   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpFrom��5      $	��140��6-   5      �� 5      $��0 0 15 0q�6   .+�5      �� $��Đến ngày��6   $��14(�6,   ���#3333336:     5      -   5        $
 dpTo��5      $	��140��6+   5      �� 5      $��0 0 15 0q�6   .+�5      �� $��Trạng thái��6   $��14(�6.   ���#3333336<   �� 5      -   5         ��Name$ cbStatus��5      $	��160��6-   $��14(�69   .@�5      �� $��
Tất cả��6#    �� 
IsSelected$
 True��64   �� 5       $
��Pass��6#   �� 5!      $
��Fail��6#   5"      5#      �� 5&      -   5         ��Name$ 	btnSearch��5&      $��Tìm kiếm��5'      $	��100��5(      $��36��6!   $��	10 20 0 0q�5)      ���#007BFF
�������$��16(�5,      $
��Bold"�5-      5.      &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ 
dgVehicles��51      $��1��52      	   AutoGenerateColumns$	 False��53      
   
IsReadOnly$

 True��54      $��16(�55      ���#333333   AlternatingRowBackground �#F0F8FF   CanUserAddRows$ False��58         CanUserDeleteRows$ False��59         Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ Biển số��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *PlateNumber+6\     5=      $ Hãng��6%   $ * 6\    6;   �� *Brand+6\     5>      $ Dòng xe��6%   $ * 6\    6;   �� *Model+6\     5?      $ Ngày đăng ký��6%   $ * 6^    6;   �� *InspectionDate+6^     5@      $ Trạng thái��6%   $ * 6\    6;   �� *Result+6\     5A      $ Trạm��6%   $ * 6\    6;   �� *StationName+6\   5C      �� 5F   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5G      �� -   5        $��Thoát��5G      $	��100��5H      $��36��6!   
����������#007BFF$��2q�5K      ���#007BFF$��16(�5M      5N      5O      5P      5Q      