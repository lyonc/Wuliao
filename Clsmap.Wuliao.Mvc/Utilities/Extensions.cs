// HtmlExtensions.cs
//
// Author:
//       Lyon <qinhutu@gmail.com>
//
// Copyright (c) 2015 © Clsmap Inc.
//
//
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using System.Globalization;

namespace Clsmap.Wuliao.Mvc.Utilities
{
    public static class ArrayExtensions
    {
        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            var collection = source as ICollection<TSource>;
            if (collection != null)
                return collection.Contains(value);
            else
                return Contains(source, value, null);
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            if (comparer == null)
                comparer = (IEqualityComparer<TSource>)EqualityComparer<TSource>.Default;

            if (source == null)
                throw new ArgumentNullException("source");

            foreach (TSource x in source)
            {
                if (comparer.Equals(x, value))
                    return true;
            }

            return false;
        }
    }

    public static class HtmlExtensions
    {
        public static MvcHtmlString NavLink(this HtmlHelper helper, string text, string action, string controller, string[] highlighteds = null)
        {
            var routeData = helper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");

            var builder = new TagBuilder("li")
            {
                InnerHtml = helper.ActionLink(text, action, controller).ToHtmlString()
            };

            if (controller == currentController &&
                (action == currentAction ||
                (highlighteds == null && highlighteds.Contains(currentAction))))
            {
                builder.AddCssClass("active");
            }

            return new MvcHtmlString(builder.ToString());
        }
    }

    public static class DateTimeExtensions
    {
        public static String ToTimestamp(this DateTime dateTime)
        {
            const String format = "西历{0:0000}年{1:00}月{2:00}日 {3} {4:00}:{5:00}";

            return String.Format(format, 
                dateTime.Year, dateTime.Month, dateTime.Day, 
                dateTime.DayOfWeek.ToString(), 
                dateTime.Hour, dateTime.Minute);
        }

    }
}

