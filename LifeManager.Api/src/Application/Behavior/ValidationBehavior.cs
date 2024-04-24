using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;

namespace LifeManage.src.Application.Behavior
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);
			var errorsDictionary = _validators
				.Select(x => x.Validate(context))
				.SelectMany(x => x.Errors)
				.Where(x => x != null)
				.GroupBy(
					x => x.PropertyName,
					x => x.ErrorMessage,
					(propertyName, errorMessages) => new
					{
						Key = propertyName,
						Values = errorMessages.Distinct().ToArray()
					})
				.ToDictionary(x => x.Key, x => x.Values);

			if (errorsDictionary.Any())
			{
				var json = JsonConvert.SerializeObject(errorsDictionary);

				throw new ValidationException(json);
			}

			return await next();
		}
		//private string GetValidationErrorMessage(IEnumerable<ValidationFailure> failures)
		//{
		//	var failureDict = failures
		//		.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
		//		.ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

		//	return string.Join(";", failureDict.Select(kv => kv.Key + ": " + string.Join(' ', kv.Value.ToArray())));
		//}
	}
}
