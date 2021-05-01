using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ExplorerGX.Core
{
    public static class ExpressionHelpers
    {
        public static T GetValue<T>(this Expression<Func<T>> lambda) => lambda.Compile().Invoke();

        public static void SetValue<T>(this Expression<Func<T>> lambda, T value)
        {
            var expression = lambda.Body as MemberExpression;

            var property = expression.Member as PropertyInfo;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            property.SetValue(target, value);
        }
    }
}
