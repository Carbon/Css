﻿namespace Carbon.Css
{
	using Carbon.Css.Parser;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	
	// Single value
	public abstract class CssValue : CssNode
	{
		public CssValue(NodeKind kind)
			: base(kind) { }

		public static CssValue Parse(string text)
		{
			#region Preconditions

			if (text == null) throw new ArgumentNullException("text");

			#endregion

			var reader = new SourceReader(new StringReader(text));

			var tokenizer = new CssTokenizer(reader, LexicalMode.Value);

			var parser = new CssParser(tokenizer);

			return parser.ReadValue();			
		}

		public static CssValue FromComponents(IEnumerable<CssValue> components)
		{
			// A property value can have one or more components.
			// Components are seperated by a space & may include functions, literals, dimensions, etc

			var enumerator = components.GetEnumerator();

			enumerator.MoveNext();

			var first = enumerator.Current;

			if (!enumerator.MoveNext())
			{
				return first;
			}

			var list = new CssValueList(ValueListSeperator.Space);

			list.Children.Add(first);
			list.Children.Add(enumerator.Current);

			while (enumerator.MoveNext())
			{
				list.Children.Add(enumerator.Current);
			}

			return list;
		}
	}
}