   M S B A M L   `   `   `  ����-  )Motorcycle-Emission-Inspection-ManagementU    OMotorcycle_Emission_Inspection_Management.InspectionFacility.FacilityReportPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Báo cáo định kỳ��5   	   $	��600��5   	   $	��900��6   ���#FFFFFF � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0,0,0,15q�6"   .+�5      �� $��Báo cáo định kỳ��6   $��26(�5      $
��Bold"�5      ���#333333 �� TextAlignment$ Center=�5      $��0,0,0,20q�5      �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $��0 0 15 0q�6   .+�5      �� $��
Từ ngày��6    $��14(�6/   ���#333333$��0 0 0 4q�6R   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpFrom��5   !   $	��130��61   5      �� 5"      $��0 0 15 0q�6   .+�5#      �� $��Đến ngày��6    $��14(�60   ���#333333$��0 0 0 4q�6S     5$      -   5        $
 dpTo��5$   !   $	��130��6/   5%      �� 5(      $��0 0 15 0q�6   .+�5)      �� $��Địa chỉ trạm��6    $��14(�64   ���#333333$��0 0 0 4q�6W   �� 5*      -   5         ��Name$ cbStationAddress��5*      $	��160��69   $��14(�6E    �� DisplayMemberPath$ Address��5+       �� SelectedValuePath$ 	StationID��6;   5,      �� 5/      $��0 0 15 0q�6   .+�50      �� $��Số điện thoại��6    $��14(�65   ���#333333$��0 0 0 4q�6X   �� 51      -   5        	 ��Name$	 tbPhone��51      $	��150��6/   $��14(�6;   52      �� 55      -   5        
 ��Name$
 	btnFilter��55      $��Lọc��56      $	��100��57      $��36��6%   $��10 0 0 0q�58      ���#007BFF
�������$��16(�5:      $
��Bold"�6'   $��0q�5;       � Cursor$
 Hand��5<      6'   5=      5>      &   System.Windows.Controls.DataGrid  5A   
   -   5          Name$ 	dgReports��5A      $��1��5B         AutoGenerateColumns$ False��5C         
IsReadOnly$
 True��5D      $��16(�5E      ���#333333   AlternatingRowBackground �#F0F8FF   CanUserAddRows$ False��5H         CanUserDeleteRows$ False��5I         Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Ngày kiểm định��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *InspectionDate+ �� StringFormat$ 
dd/MM/yyyy��6y     5M      $ Địa chỉ trạm��6%   $ * 6^    6;   �� *StationAddress+6^     5N      $ Tên trạm��6%   $ * 6W    67   �� *StationName+6W     5O      $ Số điện thoại��6%   $ * 6V    6<   �� *Phone+6V     5P      $ 	Xe đạt��6%   $ * 6U    65   �� *PassedCount+6U     5Q      $ Xe không đạt��6%   $ * 6[    6;   �� *FailedCount+6[   5S      � 5V   
   $��2��6   $��0,15,0,0q�6    � ColumnDefinitions 5W      �� 5X      $��* �6#   �� 5Y      $
��Auto �6#   �� 5Z      $
��Auto �6#   .+�5]      �� -   5        $
 btnQuit��5]      $��Thoát��5^      $	��120��5_      $��36��6!   
����������#007BFF���#007BFF$��2q�5c      $��16(�5d      $
 Hand��5e      $��1��5g      $��0 0 10 0q�5h      ��5i      �� 5j       �� 
TargetType" ��6&   .R�5k      �� #��z��6!   #��z��5l   !   #��z��5m   !    �� CornerRadius$ 8��5n   !   ._�5o      �� $��Center=�6/   $��Center=�6L   5p      5q      5s      5t      5u      5v      