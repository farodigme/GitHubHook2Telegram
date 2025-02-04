using GH2TG.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class TelegramCredentialsValidator : IValidateOptions<TelegramCredentials>
{
	public ValidateOptionsResult Validate(string name, TelegramCredentials options)
	{
		var results = new List<ValidationResult>();
		var context = new ValidationContext(options, null, null);

		if (!Validator.TryValidateObject(options, context, results, true))
		{
			var errors = string.Join("; ", results.Select(r => r.ErrorMessage));
			return ValidateOptionsResult.Fail(errors);
		}

		return ValidateOptionsResult.Success;
	}
}
