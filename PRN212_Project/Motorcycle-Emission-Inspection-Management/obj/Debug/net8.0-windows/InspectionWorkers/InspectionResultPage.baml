   M S B A M L   `   `   `  ����d  `Motorcycle-Emission-Inspection-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Iclr-namespace:Motorcycle_Emission_Inspection_Management.InspectionWorkers;Motorcycle_Emission_Inspection_Management.InspectionWorkers  5      V    PMotorcycle_Emission_Inspection_Management.InspectionWorkers.InspectionResultPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      [localIclr-namespace:Motorcycle_Emission_Inspection_Management.InspectionWorkers     5        N� Title$$  Ghi kết quả kiểm định��5   	   $	��600��5   	   $	��900��6    N� 
Background
 �����.��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $$��Ghi kết quả kiểm định��6   $��24(�5      $
��Bold"�5      ���#333333$��0,0,0,20q�5      �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   $	��Top=�69   $��0,0,0,10q�6Q   .+�5      �� $ 
Horizontal=�6   $	��0,5q�62   .+�5      �� $��Biển số xe:��6   $	��150��6/   $��Center=�6;   $��16(�6V   ���#3333336d   �� 5      -   5         ��Name$ cbPlateNumber��5       �� DisplayMemberPath$ PlateNumber��62    �� SelectedValuePath$ 	VehicleId��6R   $	��202��6p   5      �� 5       $ 
Horizontal=�6   $	��0,5q�62   .+�5!      �� $��Trạm kiểm định:��6   $	��150��63   $��Center=�5"      $��16(�6+   ���#33333369   �� 5#      -   5        $ 	cbStation��5#      $	��202��5$      $
 Name��5%      $ 	StationId��5&      5(      �� 5,      $ 
Horizontal=�6   $	��0,5q�62   .+�5-      �� $��CO Emission (ppm):��6   $	��150��66   $��Center=�6B   $��16(�6]   ���#3333336k   �� 5.      -   5        $��	COTextBox��5.   &   $	��200��6   $��16(�67   5/      �� 51      $ 
Horizontal=�6   $	��0,5q�62   .+�52      �� $��HC Emission (ppm):��6   $	��150��66   $��Center=�6B   $��16(�6]   ���#3333336k   �� 53      -   5        $��	HCTextBox��53   &   $	��200��6   $��16(�67   54      �� 56      $ 
Horizontal=�6   $	��0,4q�62   .+�57      �� $��Ngày kiểm định:��6   $	��150��64   $��Center=�6@   $��16(�6[   ���#3333336i   (  "System.Windows.Controls.DatePicker  58      -   5          Name$ dpInspectDate��58      $	��200��5:      5<      �� 5=      $ 
Horizontal=�6   $	��0,5q�62   .+�5>      �� $��Trạng thái:��6   $	��150��6/   $��Center=�6;   $��16(�6V   ���#3333336d   �� 5?      -   5        $��ResultComboBox��5?   '   $	��200��6   $��16(�6=   .@�5@      �� $
��Pass��6#   �� 5A      $
��Fail��6#   5B      5C      �� 5E      $ 
Horizontal=�6   $	��0,5q�62   .+�5F      �� $��	Ghi chú:��6   $	��150��6,   $	��Top=�68   $��16(�6P   ���#3333336^   �� 5G      -   5        $��CommentsTextBox��5G   2   $	��400��6   $��80��6&    �� TextWrapping$
 Wrap=�6I   	 �� AcceptsReturn$
	 True��6]   $��16(�6r   5H      �� 5J      -   5        $��Lưu kết quả��5J      $	��140��5K      $��44��5L      $��16(�5M      $
��Bold"�5N      
����������#007BFF$��0,15,0,0q�5Q      $
��Left=�5R      60   5S      5V      5W      