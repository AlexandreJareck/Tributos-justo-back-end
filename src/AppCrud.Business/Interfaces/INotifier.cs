using AppCrud.Business.Notifications;

namespace AppCrud.Business.Interfaces;

public interface INotifier
{
    bool HaveNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
