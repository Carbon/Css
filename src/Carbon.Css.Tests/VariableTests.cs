﻿namespace Carbon.Css.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class VariableTests
	{
		[Test]
		public void VariableTest1()
		{
			var sheet = StyleSheet.Parse(
@"
$blue: #dceef7;
$yellow: #fff5cc;

body { 
  background-color: $blue;
  color: $yellow;
}
");

			Assert.AreEqual(
@"body {
  background-color: #dceef7;
  color: #fff5cc;
}", sheet.ToString());
		}

		[Test]
		public void VariableTest3()
		{
			var context = new CssContext();

			context.Variables.Set("monster", CssPrimitiveValue.Parse("red"));

			var sheet = StyleSheet.Parse(
@"
$blue: #dceef7;
$yellow: #fff5cc;

body { 
  background-color: $blue;
  color: $yellow;
  monster: $monster;
}
", context);


			Assert.AreEqual(
@"body {
  background-color: #dceef7;
  color: #fff5cc;
  monster: red;
}", sheet.ToString());
		}


		[Test]
		public void VariableTest2()
		{
			var styles =
@"
$addYellow: #fff5cc;
$editBlue: #dceef7;

body { font-size: 14px; opacity: 0.5; }
.editBlock button.save { background: $addYellow; }
.editBlock.populated button.save { background: $editBlue; }
.rotatedBox { box-sizing: border-box; }
			";

			var sheet = StyleSheet.Parse(styles);

			// Adds a filter: alpha(opacity) property to support opacity in IE8
			// Ads vendor prefixed properties for box-sizing for Safari (Firefox 4 natively implements it)
			// sheet.SetCompatibility(Browser.Chrome10, Browser.Firefox4, Browser.IE8, Browser.Safari5);


			Assert.AreEqual(
@"body {
  font-size: 14px;
  opacity: 0.5;
}
.editBlock button.save { background: #fff5cc; }
.editBlock.populated button.save { background: #dceef7; }
.rotatedBox { box-sizing: border-box; }", sheet.ToString());


		}
	}
}
