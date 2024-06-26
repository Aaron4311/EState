﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Validation
{
	public class ValidationAspect : MethodInterception
	{
		private Type _validatorType;
		public ValidationAspect(Type validatorType)
		{
			if (!typeof(IValidator).IsAssignableFrom(validatorType))
			{
				throw new Exception($"{validatorType.Name} is not found");
			}
			_validatorType = validatorType;
		}

		public override void OnBefore(IInvocation invocation)
		{
			var validator = (IValidator)Activator.CreateInstance(_validatorType);
			var entityType = _validatorType.BaseType.GetGenericArguments()[0];
			var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

			foreach (var entity in entities)
			{
				ValidationTool.Validate(validator, entity);
			}
		}
	}
}
