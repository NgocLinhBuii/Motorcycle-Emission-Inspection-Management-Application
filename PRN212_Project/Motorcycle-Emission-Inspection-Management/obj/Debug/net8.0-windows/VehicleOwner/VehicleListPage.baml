   M S B A M L   `   `   `  ����d  `Motorcycle-Emission-Inspection-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:Motorcycle_Emission_Inspection_Management.VehicleOwner6Motorcycle_Emission_Inspection_Management.VehicleOwner  5   	   L    FMotorcycle_Emission_Inspection_Management.VehicleOwner.VehicleListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   VlocalDclr-namespace:Motorcycle_Emission_Inspection_Management.VehicleOwner     5   	     N� Title$   Danh sách phương tiện��5   	   $	��960��5   	   $	��580��6    N� 
Background �#F8F9FA.��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $0��*Danh sách phương tiện đã đăng ký��6   $��26(�5      $
��Bold"�5      ���#2C3E50$��Center=�5      $��	0,10,0,10q�5      $��0��5      � 5   
   $��1��6   $��0,0,0,10q�5       $��Center=�5!      $��Center=�5"      $	��860��5#       � ColumnDefinitions 5$      �� 5%      $	��180 �6#   �� 5'      $��20 �6#   �� 5(      $	��180 �6#   �� 5*      $��40 �6#   �� 5+      $	��120 �6#   �� 5-      $��20 �6#   �� 5.      $	��100 �6#   .+�53      �� $��0��6   .+�54      �� $��Biển số xe��6   $��14(�55      $��SemiBold"�56      ���#333$��0,0,0,4q�58      �� 59      -   5         ��Name$ txtPlateFilter��59      $	��180��5:      $��30��5;      $��5q�5<      
����������#CED4DA$��1q�5?      5@      �� 5C      $��2��6   .+�5D      �� $��Model��6   $��14(�5E      $��SemiBold"�5F      ���#333$��0,0,0,4q�5H      �� 5I      -   5        $ txtModelFilter��5I      $	��180��5J      $��30��5K      $��5q�5L      
����������#CED4DA$��1q�5O      5P      �� 5S      -   5         ��Name$ 	btnSearch��5S      $��4��5T      $��🔍 Tìm kiếm��5U      $	��120��5V      $��36��6!   $��Bottom=�5W      ���#007BFF
�������$��SemiBold"�5Z      $��14(�5[       � Cursor$
 Hand��5\      $��0q�5]      5^      �� 5a      -   5        $ 	btnDelete��5a      $��6��5b      $��🗑 Xóa xe��5c      $	��100��5d      $��36��6!   $��Bottom=�5e      ���#DC3545
�������$��SemiBold"�5h      $��14(�5i      $
 Hand��5j      $��0q�5k      5l      5m      &   System.Windows.Controls.DataGrid  5p   
   -   5          Name$ 
dgVehicles��5p      $��2��5q         AutoGenerateColumns$ False��5r      	   
IsReadOnly$
	 True��5s      
   CanUserAddRows$
 False��5t         HeadersVisibility$ Column=�5u         GridLinesVisibility$	 All=�5v      $��14(�5w         AlternatingRowBackground �#F0F2F5���#DDE2E5$��	0,10,0,10q�5z         SelectionMode$ Single=�5{         Columns 5~      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Biển số��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *PlateNumber+6V     5�      $ Hãng��6%   $ * 6M    63   �� *Brand+6M     5�      $ Dòng xe��6%   $ * 6P    66   �� *Model+6P     5�      $ Năm SX��6%   $ * 6Y    65   �� *ManufactureYear+6Y     5�      $ 	Số máy��6%   $ * 6V    65   �� *EngineNumber+6V   5�      �� 5�   
   $��3��6    �� Orientation$ 
Horizontal=�5�      $��Right=�5�      $��	0,10,10,0q�5�      5�      5�      5�      