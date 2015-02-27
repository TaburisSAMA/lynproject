using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CommonUtilities.Extensions
{
    public static class EntityFrameworkExtension
    {

        public static void DeleteObjects<T>(this ObjectContext context, ObjectQuery<T> query)
        {

            // Delete objects
            ObjectResult<T> result = query.Execute(MergeOption.AppendOnly);
            IEnumerator enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects

        // DeleteObjects
        public static void DeleteObjects<T>(this ObjectContext context, IEnumerable<T> query)
        {

            // Delete objects      
            IEnumerator enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects

        // DeleteObjects
        public static void DeleteObjects<T>(this ObjectContext context, IList<T> query)
        {

            // Delete objects      
            IEnumerator enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects

        // DeleteObjects
        public static void DeleteObjects<T>(this ObjectContext context, IQueryable<T> query)
        {

            // Delete objects      
            IEnumerator enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                T obj = (T)enumerator.Current;
                context.DeleteObject(obj);
            }

        } // DeleteObjects


        public static IQueryable<TEntity> WhereIn<TEntity, TValue>(this ObjectQuery<TEntity> query, Expression<Func<TEntity, TValue>> selector, IEnumerable<TValue> collection)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (collection == null) throw new ArgumentNullException("collection");
            ParameterExpression p = selector.Parameters.Single();

            if (!collection.Any()) return query;

            IEnumerable<Expression> equals = collection.Select(value => (Expression)Expression.Equal(selector.Body, Expression.Constant(value, typeof(TValue))));

            Expression body = equals.Aggregate((accumulate, equal) => Expression.Or(accumulate, equal));

            return query.Where(Expression.Lambda<Func<TEntity, bool>>(body, p));
        }

        //Optional - to allow static collection:
        public static IQueryable<TEntity> WhereIn<TEntity, TValue>(this ObjectQuery<TEntity> query, Expression<Func<TEntity, TValue>> selector, params TValue[] collection)
        {
            return WhereIn(query, selector, (IEnumerable<TValue>)collection);
        }
    }

}
