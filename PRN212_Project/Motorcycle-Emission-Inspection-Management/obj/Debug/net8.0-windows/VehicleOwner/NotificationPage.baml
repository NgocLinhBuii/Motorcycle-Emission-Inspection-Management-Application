   M S B A M L   `   `   `  ����d  `Motorcycle-Emission-Inspection-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:Motorcycle_Emission_Inspection_Management.VehicleOwner6Motorcycle_Emission_Inspection_Management.VehicleOwner  5      M    GMotorcycle_Emission_Inspection_Management.VehicleOwner.NotificationPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      VlocalDclr-namespace:Motorcycle_Emission_Inspection_Management.VehicleOwner     5        N� Title$  Thông báo��5   	   $	��960��5   	   $	��580��6    N� 
Background �#F9FAFB.��5	      �� 
�������$��20q�5
       �� CornerRadius$ 10��5       �� Padding$ 20q�5      ���#DDE2E5$��1q�5         DropShadowEffect J� Effect# �   5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� $!��📬 Danh sách thông báo��6   $��26(�5      $
��Bold"�5      ���#2C3E50$��Center=�5       $��0 0 0 20q�5!      &   System.Windows.Controls.DataGrid  5$      -   5          Name$ dgNotifications��5$      $��1��5%         AutoGenerateColumns$ False��5&         
IsReadOnly$
 True��5'      	   CanUserAddRows$	 False��5(      
   AlternatingRowBackground
 �#F0F8FF   GridLinesVisibility$ 
Horizontal=�5*      $��14(�5+         HeadersVisibility$ Column=�5,      $��0q�5-      ���#DDD   	RowHeight$ 36Q�5/         SelectionMode$ Single=�50         Columns 52      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Thời gian��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 55   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 56   )   �� *
SentDate+ �� StringFormat$ dd/MM/yyyy HH:mm��  58      $ 
Nội dung��6)   $ * 5:   )    59   )   �� *	Message+5:   )   4  .System.Windows.Controls.DataGridCheckBoxColumn  5<      $ Đã đọc��6-   $ 80 5>   -    5=   -   �� *IsRead+5>   -   4  .System.Windows.Controls.DataGridTemplateColumn  5A      $  ��6-   $	 140 68      
IsReadOnly$ False��6D      CellTemplate 5B      �� 5C      .R�5D   "   �� -   5        $"��✔ Đánh dấu đã đọc��5D   )   $	��6 2q�5E   )   $��12(�5F   )   ���#28A745
�������$��0q�5I   )    � Cursor$
 Hand��5J   )   ��5L   &   �� 5M   *    �� 
TargetType" ��60   .�5N   .   ��  �� Property � y� �� Value$ Visible=�6K    �� Triggers 5O   .   �� 5P   2    �� Binding 6>   �� *IsRead+ �� Value True6Y   .a�5Q   6   ��  � y�$ 	Collapsed=�6S   5R   3   5T   +   5V   #   5W      5Y      5[      �� 5^      $��2��6    �� Orientation$ 
Horizontal=�5_      $��Right=�5`      $��0 20 0 0q�5a      .+�5b      �� -   5        $��🔄 Tải lại��5b      $	��110��5c      $��36��6%   ���#007BFF
�������$��SemiBold"�5f      $
 Hand��5g      5h      5k      5l      5m       � 	Resources 5p      3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius    ShadowDepth!   Color"   Opacity��%c   &	          5q   
   $ 10Q�5r      $  2Q�5s      $
! Gray��5t      $
" 0.15Q�5u      5v      5w      