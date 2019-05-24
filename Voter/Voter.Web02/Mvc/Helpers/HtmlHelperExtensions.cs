using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Kontrola, zda stránka obsahuje akci
        /// </summary>
        /// <param name="html"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool HasAction(this HtmlHelper html, string action)
        {
            // TODO fix!

            //var actions = (IEnumerable<string>)html.ViewBag.Actions;
            //return actions != null && actions.Contains(action);

            return !action.Contains("CR_EntityLog");
        }
    }
}