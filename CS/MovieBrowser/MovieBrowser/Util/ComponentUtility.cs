using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightIdeasSoftware;

namespace MovieBrowser.Util
{
    public static class ComponentUtility
    {
        public static void TimedFilter(ObjectListView olv, string txt, TextMatchFilter.MatchKind matchKind = TextMatchFilter.MatchKind.Text)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
                filter = new TextMatchFilter(olv, txt, matchKind);

            // Setup a default renderer to draw the filter matches
            olv.DefaultRenderer = filter == null ? null : new HighlightTextRenderer(filter);

            // Some lists have renderers already installed
            var highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;

            olv.ModelFilter = filter;
        }
    }
}
