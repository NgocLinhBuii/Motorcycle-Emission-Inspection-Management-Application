using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Motorcycle_Emission_Inspection_Management.BLL.Services;
using Motorcycle_Emission_Inspection_Management.Common;
using Motorcycle_Emission_Inspection_Management.DAL.Entities;

namespace Motorcycle_Emission_Inspection_Management.VehicleOwner
{
    public partial class NotificationPage : Page
    {
        private readonly NotificationService _notificationService = new();   // chỉ còn 1 service

        public NotificationPage()
        {
            InitializeComponent();
            LoadNotifications();
        }

        /* ===== Lấy thông báo của chủ xe đang đăng nhập ===== */
        private void LoadNotifications()
        {
            int ownerId = UserSession.UserId;
            List<Notification> list = _notificationService.GetByUserId(ownerId);

            dgNotifications.ItemsSource = list
                                          .OrderByDescending(n => n.SentDate)
                                          .ToList();
        }

        /* ===== Đánh dấu đã đọc qua nút trong cột ===== */
        private void MarkRead_Click(object sender, RoutedEventArgs e)
        {
            // pattern-matching Button + lấy Notification
            if (sender is Button { DataContext: Notification noti } && noti.IsRead != true)
            {
                _notificationService.MarkAsRead(noti.NotificationId);

                noti.IsRead = true;           // cập nhật trạng thái
                dgNotifications.Items.Refresh();
            }
        }


        /* ===== Tải lại danh sách ===== */
        private void btnReload_Click(object sender, RoutedEventArgs e) => LoadNotifications();

        /* ===== Thoát ===== */
        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
