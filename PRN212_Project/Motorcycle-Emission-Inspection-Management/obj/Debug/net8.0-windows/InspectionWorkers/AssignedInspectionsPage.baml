   M S B A M L   `   `   `  ����d  `Motorcycle-Emission-Inspection-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Iclr-namespace:Motorcycle_Emission_Inspection_Management.InspectionWorkers;Motorcycle_Emission_Inspection_Management.InspectionWorkers  5      Z    TMotorcycle_Emission_Inspection_Management.InspectionFacility.AssignedInspectionsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      [localIclr-namespace:Motorcycle_Emission_Inspection_Management.InspectionWorkers     5        N� Title$9  3Danh sách xe được giao kiểm định hôm nay��5   	    N� 
Background �#F5F7FA.��5      �� 
�������$��20q�5	       �� Padding$ 20q�5
       �� CornerRadius$ 10��5      ���#DDE2E5$��1q�5         DropShadowEffect J� Effect# �   5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�5      $��0,0,0,15q�5      .+�5      �� -   5         ��Name$ txtPlateNumber��5      $	��160��5      $��14(�5      
�������$��Biển số��5!      $��8q�5$      (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ dpDate��5'      $	��160��5(      $��14(�5)      $��4q�5*      �� 5-      -   5        	 ��Name$	 cbStatus��5-      $	��150��5.      $��14(�5/      $��4q�50      .@�51      �� $��
Tất cả��6#   
 �� 
IsSelected$

 True��64   �� 52      $
��Pass��6#   �� 53      $
��Fail��6#   54      �� 57      -   5         ��Name$ 	btnSearch��58      $��🔍 Tìm kiếm��57      $	��120��59      $��36��6%   $��14(�5:      $��SemiBold"�5;      ���#007BFF
�������$��0q�5>       � Cursor$
 Hand��5?      5@      5A      &   System.Windows.Controls.DataGrid  5D      -   5          Name$  AssignedInspectionDataGrid��5D      $��1��5E         AutoGenerateColumns$ False��5F         CanUserAddRows$ False��5G         
IsReadOnly$
 True��5H      $��14(�5I         AlternatingRowBackground �#F0F8FF   GridLinesVisibility$ 
Horizontal=�5K         	RowHeight$ 36Q�5L         HeadersVisibility$ Column=�5M         Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Biển số��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6l   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *Vehicle.PlateNumber+6l     5R      $ Hãng��6)   $ * 6l    6@   �� *Vehicle.Brand+6l     5S      $ Model��6)   $ * 6l    6@   �� *Vehicle.Model+6l     5T      $ Ngày kiểm định��6)   $ * 6}    6A   �� *InspectionDate+ �� StringFormat$ 
dd/MM/yyyy��6}     5U      $ Trạng thái��6)   $ * 6d    6@   �� *Result+6d     5V      $ Mức thải CO₂��6)   $ * 6d    6@   �� *Co2emission+6d     5W      $ Trạm kiểm định��6)   $ * 6f    6A   �� *Station.Name+6f     5X      $ 	Ghi chú��6)   $ * 6\    6;   �� *
Comments+6\   5Z      5]      5^       � 	Resources 5a      3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Color   Opacity��%c   &	          5b   
   $ 10Q�5c      $ 2Q�5d      $
 Gray��5e      $
 0.15Q�5f      5g      5h      