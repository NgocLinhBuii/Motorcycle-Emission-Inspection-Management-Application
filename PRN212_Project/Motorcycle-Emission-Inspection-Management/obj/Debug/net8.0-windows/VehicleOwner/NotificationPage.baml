   M S B A M L   `   `   `  ����-  )Motorcycle-Emission-Inspection-ManagementM    GMotorcycle_Emission_Inspection_Management.VehicleOwner.NotificationPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Thông báo��5   	   $	��520��5   	   $	��920��6    � WindowStartupLocation$ CenterScreen=�5   	   
�������.��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Danh sách thông báo��6   $��24(�5      $
��Bold"�6"   ���#333333$��0 0 0 15q�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgNotifications��5      $��1��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5         AlternatingRowBackground �#F0F8FF$��14(�5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Thời gian��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 160 5#   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5$   %   �� *
SentDate+ �� StringFormat$ dd/MM/yyyy HH:mm��  5&      $ 
Nội dung��6%   $	 * 5(   %   
 5'   %   �� *	Message+5(   %   4  .System.Windows.Controls.DataGridCheckBoxColumn  5*      $ Đã đọc��6)   $	 80 5,   )   
 5+   )   �� *IsRead+5,   )   4  .System.Windows.Controls.DataGridTemplateColumn  5.      $  ��6)   $		 120 64      
IsReadOnly$ False��6@      CellTemplate 5/      �� 50      .R�51      �� -   5        $��Đánh dấu đã đọc��51   %   $	��6 2q�52      $��12(�53      ���#28A745
�������$��0q�56       � Cursor$
 Hand��57      ��59   "   �� 5:   &    �� 
TargetType" ��6,   .�5;   *   ��  �� Property � y� �� Value$ Visible=�6G    �� Triggers 5<   *   �� 5=   .    �� Binding 6:   �� *IsRead+ �� Value True6U   .a�5>   2   ��  � y�$ 	Collapsed=�6O   5?   /   5A   '   5C      5D      5F      5I      �� 5L   
   $��2��6    �� Orientation$ 
Horizontal=�5M      $��Right=�5N      $��0 10 0 0q�5O      .+�5P      �� -   5        $��Tải lại��5P      $	��100��5Q      $��36��6!   ���#007BFF
�������$
��Bold"�5S      $��0 0 10 0q�5T      5U      �� 5W      -   5        $��Thoát��5W      $	��100��5X      $��36��6!   
����������#007BFF$��2q�5[      ���#007BFF$
��Bold"�5]      5^      5_      5`      5a      