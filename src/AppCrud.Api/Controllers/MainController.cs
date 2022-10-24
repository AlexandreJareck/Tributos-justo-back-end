using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using AppCrud.Business.Interfaces;
using AppCrud.Business.Notifications;

namespace AppCrud.Api.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotifier _notifier;

    public MainController(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected ActionResult CustomResponse(object? result = null)
    {
        if (IsOperationValid())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = _notifier.GetNotifications().Select(n => n.Message)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            NotificationErrorModelInvalid(modelState);

        return CustomResponse();
    }

    protected void NotifyErrors(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected bool IsOperationValid()
    {
        return !_notifier.HaveNotification();
    }

    protected void NotificationErrorModelInvalid(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);

        foreach (var error in errors)
        {
            var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

            NotifyErrors(errorMessage);
        }
    }
}
