using AppCrud.Business.Interfaces;
using AppCrud.Business.Models;
using AppCrud.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace AppCrud.Business.Services;

public class BaseService
{
    private readonly INotifier _notifier;

	public BaseService(INotifier notifier)
	{
        _notifier = notifier;
    }
    protected void Notify(ValidationResult validationResult)
    {
        validationResult.Errors.ForEach(e => Notify(e.ErrorMessage));
    }

    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid)
            return true;

        Notify(validator);

        return false;
    }
}
