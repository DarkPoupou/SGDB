using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.Common.Helpers;
public static class ValidatorHelper
{
    public static IRuleBuilderOptions<T, TProperty> LessThanWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
    => ruleBuilder.LessThan(valueToCompare).WithMessage($"{{PropertyName}} should be less than {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");
    public static IRuleBuilderOptions<T, TProperty?> LessThanWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare) where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.LessThan(valueToCompare).WithMessage($"{{PropertyName}} should be less than {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");

    public static IRuleBuilderOptions<T, TProperty> LessThanOrEqualWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.NotNull().LessThanOrEqualTo(valueToCompare).WithMessage($"{{PropertyName}} should be less than or eqaul to {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");
    public static IRuleBuilderOptions<T, TProperty?> LessThanOrEqualWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare) where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.NotNull().LessThanOrEqualTo(valueToCompare).WithMessage($"{{PropertyName}} should be less than or eqaul to {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");

    public static IRuleBuilderOptions<T, TProperty> GreatherThanWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThan(valueToCompare).WithMessage($"{{PropertyName}} should be greather than {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");
    public static IRuleBuilderOptions<T, TProperty?> GreatherThanWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare) where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThan(valueToCompare).WithMessage($"{{PropertyName}} should be greather than {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");

    public static IRuleBuilderOptions<T, TProperty> GreatherThanOrEqualWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, TProperty valueToCompare) where TProperty : IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThanOrEqualTo(valueToCompare).WithMessage($"{{PropertyName}} should be greather than or eqaul to {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");
    public static IRuleBuilderOptions<T, TProperty?> GreatherThanOrEqualWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty?> ruleBuilder, TProperty valueToCompare) where TProperty : struct, IComparable<TProperty>, IComparable
        => ruleBuilder.GreaterThanOrEqualTo(valueToCompare).WithMessage($"{{PropertyName}} should be greather than or eqaul to {valueToCompare}\n{{PropertyName}} was equal to {{PropertyValue}}");

}
