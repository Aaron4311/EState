﻿using FluentValidation;
using System.ComponentModel.DataAnnotations;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
	public class ValidationTool
    {
		public static void Validate(IValidator validator, object entity)
		{
			var context = new ValidationContext<object>(entity);
			var result = validator.Validate(context);

			if (!result.IsValid)
			{
				throw new ValidationException(result.Errors);
			}
		}
	}
}
