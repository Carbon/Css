﻿namespace Carbon.Css
{
	using System.Collections.Generic;

	public class IEOpacityTransform : ICssRewriter
	{
		public IEnumerable<CssRule> Rewrite(CssRule rule)
		{
			var declaration = rule.Get("opacity");

			if (declaration == null)
			{
				yield return rule;

				yield break;
			}

			var value = declaration.Value as CssNumber;

			if (value == null)
			{
				yield return rule;

				yield break;
			}

			var index = rule.IndexOf(declaration);

			// Add the filter before the standard
			rule.Insert(index, new CssDeclaration("filter", "alpha(opacity=" + value + ")"));

			yield return rule;
		}
	}
}