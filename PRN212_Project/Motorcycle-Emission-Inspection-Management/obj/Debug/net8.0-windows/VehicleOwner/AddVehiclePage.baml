   M S B A M L   `   `   `  ����d  `Motorcycle-Emission-Inspection-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:Motorcycle_Emission_Inspection_Management.VehicleOwner6Motorcycle_Emission_Inspection_Management.VehicleOwner  5   
   K    EMotorcycle_Emission_Inspection_Management.VehicleOwner.AddVehiclePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   
   VlocalDclr-namespace:Motorcycle_Emission_Inspection_Management.VehicleOwner     5   
     N� Title$  Thêm phương tiện��5   	   $	��960��5   	   $	��580��6    N� 
Background �#F9FAFB.��5	      �� 
������� �� CornerRadius$ 10��5
       �� Padding$ 30q�5      $��30q�5      ���#DDE2E5$��1q�5         DropShadowEffect J� Effect# �   5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $ ��🛵 Thêm phương tiện��6   $��26(�5      $
��Bold"�5      ���#2C3E50$��Center=�5      $��0,0,0,20q�5      � 5!      $��1��6   $��0,0,0,20q�5"       � ColumnDefinitions 5#      �� 5$      $	��180 �6'   �� 5%      $��* �6'    5(      �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      $
��Auto �6$   �� 5,      $
��Auto �6$   �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   .+�52      �� $��Biển số xe:��6   $��0��6/   $��0��6<   $��15(�6L   $��Center=�6Z   $
��0,10q�6u   �� 53      -   5         ��Name$ tbPlate��53      $��0��6+   $��1��68   $��34��6H   $��14(�6T   $��6q�6b   $
��0,10q�6n   �� 56      $��	Hãng xe:��6   $��1��6,   $��0��69   $��15(�6I   $��Center=�6W   $
��0,10q�6r   �� 57      -   5        $ tbBrand��57      $��1��6+   $��1��68   $��34��6H   $��14(�6T   $��6q�6b   $
��0,10q�6n   �� 5:      $��	Dòng xe:��6   $��2��6,   $��0��69   $��15(�6I   $��Center=�6W   $
��0,10q�6r   �� 5;      -   5        $ tbModel��5;      $��2��6+   $��1��68   $��34��6H   $��14(�6T   $��6q�6b   $
��0,10q�6n   �� 5>      $��Năm sản xuất:��6   $��3��61   $��0��6>   $��15(�6N   $��Center=�6\   $
��0,10q�6w   �� 5?      -   5        $ tbYear��5?      $��3��6*   $��1��67   $��34��6G   $��14(�6S   $��6q�6a   $
��0,10q�6m   �� 5B      $��
Số máy:��6   $��4��6+   $��0��68   $��15(�6H   $��Center=�6V   $
��0,10q�6q   �� 5C      -   5        $ tbEngine��5C      $��4��6,   $��1��69   $��34��6I   $��14(�6U   $��6q�6c   $
��0,10q�6o   5D      �� 5G      $��2��6    �� Orientation$ 
Horizontal=�5H      $��Center=�5I      $��0,10,0,0q�5J      .+�5K      �� -   5        	 ��Name$	 btnSave��5K      $��	💾 Lưu��5L      $	��130��5M      $��40��6%   ���#007BFF
�������$��16(�5P      $��SemiBold"�5Q      
 � Cursor$

 Hand��5R      $��0q�5S      5T      5V      5W      5X       � 	Resources 5[      3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Color   Opacity��%c   &	          5\   
   $ 10Q�5]      $ 2Q�5^      $
 Gray��5_      $
 0.15Q�5`      5a      5b      