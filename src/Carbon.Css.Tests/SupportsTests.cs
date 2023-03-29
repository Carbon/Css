﻿namespace Carbon.Css.Tests;

public class SupportRuleTests
{
    [Fact]
    public void A()
    {
        var sheet = StyleSheet.Parse(
            """
            @supports (-moz-appearance: none) {
              .video-controls__progress {
                height: 4px;
                bottom: 1.9vw;
                background: rgba(#fff, 40%);
              }
            }
            """);


        Assert.Equal(
            """
            @supports (-moz-appearance: none) {
              .video-controls__progress {
                height: 4px;
                bottom: 1.9vw;
                background: rgba(255, 255, 255, 0.4);
              }
            }
            """, sheet.ToString());
    }
}