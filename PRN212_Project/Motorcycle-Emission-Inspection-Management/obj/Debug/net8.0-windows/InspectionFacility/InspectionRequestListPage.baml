   M S B A M L   `   `   `  ����d  `Motorcycle-Emission-Inspection-Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Jclr-namespace:Motorcycle_Emission_Inspection_Management.InspectionFacility<Motorcycle_Emission_Inspection_Management.InspectionFacility  5      \    VMotorcycle_Emission_Inspection_Management.InspectionFacility.InspectionRequestListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \localJclr-namespace:Motorcycle_Emission_Inspection_Management.InspectionFacility     5        N� Title$:  4Danh sách phương tiện đăng ký kiểm định��5   	   $	��600��5   	   $	��900��6    N� 
Background �#F5F7FA.��5	      �� 
������� �� CornerRadius$ 10��5
       �� Padding$ 20q�5      $��20q�5      ���#DDE2E5$��1q�5         DropShadowEffect J� Effect# �   5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0 0 0 15q�62   .+�5      �� .+�5      �� $��
Từ ngày��6    $��14(�6/   $��SemiBold"�6=   ���#3336S   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpFrom��5   !   $	��150��61   5      �� 5!      .+�5"      �� $��Đến ngày��6    $��14(�60   $��SemiBold"�6>   ���#3336T     5#      -   5        $
 dpTo��5#   !   $	��150��6/   5$      �� 5'      .+�5(      �� $��Trạng thái��6    $��14(�62   $��SemiBold"�6@   ���#3336V   �� 5)      -   5         ��Name$ cbStatus��5)      $	��160��61   $��14(�6=   .@�5*      �� $��
Tất cả��6'   	 �� 
IsSelected$
	 True��68   �� 5+      $
��Pass��6'   �� 5,      $
��Fail��6'   5-      5.      �� 51      -   5        
 ��Name$
 	btnSearch��51      $��🔍 Tìm kiếm��52      $	��120��53      $��26��6%   $��	10,20,0,0q�54      ���#007BFF
�������$��14(�57      $��SemiBold"�58       � Cursor$
 Hand��59      $��0q�5:      5;      5<      &   System.Windows.Controls.DataGrid  5?      -   5          Name$ 
dgVehicles��5?      $��1��5@         AutoGenerateColumns$ False��5A         
IsReadOnly$
 True��5B      $��14(�5C      ���#333   AlternatingRowBackground �#F0F8FF   	RowHeight$ 36Q�5F         HeadersVisibility$ Column=�5G         CanUserAddRows$ False��5H         CanUserDeleteRows$ False��5I         Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Biển số��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *PlateNumber+6g     5M      $ Hãng��6)   $ * 6f    6?   �� *Brand+6f     5N      $ Dòng xe��6)   $ * 6f    6?   �� *Model+6f     5O      $ Ngày đăng ký��6)   $ * 6{    6?   �� *InspectionDate+ �� StringFormat$ 
dd/MM/yyyy��6{     5P      $ Trạng thái��6)   $ * 6f    6?   �� *Result+6f     5Q      $ Trạm��6)   $ * 6f    6?   �� *StationName+6f   5S      5V      5W       � 	Resources 5Z      3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth   Color   Opacity��%d   &	          5[   
   $ 8Q�5\      $ 2Q�5]      $ #999999��5^      $	 0.2Q�5_      5`      5a      