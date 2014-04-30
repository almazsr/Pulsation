using System;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace Pulsation.WinForms.Helpers
{
    public static class BindingHelper
    {
        public static void AddBinding<T, U>(this T control, Expression<Func<T, object>> property,
            U dataSource,
            Expression<Func<U, object>> dataMember, DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnValidation)
            where T : Control
            where U : class
        {
            control.DataBindings.Add(GetPropertyPath(property.Body), dataSource, GetPropertyPath(dataMember.Body), false,
                                     dataSourceUpdateMode);
        }

        public static string GetPropertyPath(Expression expression)
        {
            MemberExpression memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }
            UnaryExpression unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null)
            {
                string operand = unaryExpression.Operand.ToString();
                return string.Join(".", operand.Split('.').Skip(1));
            }
            throw new NotImplementedException();
        }
    }
}