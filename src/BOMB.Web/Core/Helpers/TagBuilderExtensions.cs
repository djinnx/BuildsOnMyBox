﻿namespace BOMB.Web.Core.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Tag Builder Extension methods
    /// </summary>
    public static class TagBuilderExtensions
    {
        /// <summary>
        /// Convert tagbuilder to an MVC HTML string.
        /// </summary>
        /// <param name="tagBuilder">The tag builder.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder)
        {
            return tagBuilder.ToString().ToMvcHtmlString();
        }

        /// <summary>
        /// Convert tagbuilder to an MVC HTML string.
        /// </summary>
        /// <param name="tagBuilder">The tag builder.</param>
        /// <param name="tagRenderMode">The tag render mode.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode tagRenderMode)
        {
            return tagBuilder.ToString(tagRenderMode).ToMvcHtmlString();
        }
    }
}