using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace CommonUtilities.Extensions
{
    public static class ControlExtension
    {
        private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

        public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        {
            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
            //var two = !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType);
            if (propertyInfo == null || @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
            {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired)
            {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
            }
            else
            {
                @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
            }
        }
    }

}
