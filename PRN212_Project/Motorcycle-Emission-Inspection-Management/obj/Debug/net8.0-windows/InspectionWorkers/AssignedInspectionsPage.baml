   M S B A M L   `   `   `  ����-  )Motorcycle-Emission-Inspection-ManagementZ    TMotorcycle_Emission_Inspection_Management.InspectionFacility.AssignedInspectionsPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$9  3Danh sách xe được giao kiểm định hôm nay��5   	   $	��600��5   	   $	��900��6   
������� � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5         ��Name$ txtPlateNumber��5      $��Biển số��5   
   
�������$	��150��5   
   $��0,0,10,0q�5   
   $��14(�5   
   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpDate��5      $	��150��5      $��0,0,10,0q�5      $��14(�5       �� 5#      -   5         ��Name$ cbStatus��5#      $	��140��5$      $��0,0,10,0q�5%      $��14(�5&      .@�5'      �� $��
Tất cả��6    �� 
IsSelected$
 True��65   �� 5(      $
��Pass��6   �� 5)      $
��Fail��6   5*      �� 5-      -   5         ��Name$ 	btnSearch��5.      $��Tìm kiếm��5-      $	��100��5/      $��36��6   ���#007BFF
�������$��16(�52      $
��Bold"�53      6   55      &   System.Windows.Controls.DataGrid  59   
   -   5        	  Name$ 	 AssignedInspectionDataGrid��59      $��1��5:      
   AutoGenerateColumns$
 False��5;         CanUserAddRows$ False��5<         
IsReadOnly$
 True��5=      $��14(�5>         AlternatingRowBackground �#F0F8FF���#333333   Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Biển số��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Vehicle.PlateNumber+6h     5C      $ Hãng��6%   $ * 6h    6<   �� *Vehicle.Brand+6h     5D      $ Model��6%   $ * 6h    6<   �� *Vehicle.Model+6h     5E      $ Ngày kiểm định��6%   $ * 6y    6=   �� *InspectionDate+ �� StringFormat$ 
dd/MM/yyyy��6y     5F      $ Trạng thái��6%   $ * 6`    6<   �� *Result+6`     5G      $ Mức thải CO2��6%   $ * 6e    6A   �� *Co2emission+6e     5H      $ Station Name��6%   $ * 6f    6A   �� *Station.Name+6f   5J      �� 5M   
   $��2��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5N      �� -   5        $��Thoát��5N      $	��100��5O      $��36��6!   
����������#007BFF$��2q�5R      ���#007BFF$��16(�5T      5U      5V      5W      5X      