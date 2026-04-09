using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTailwind.DesignSystem.TagHelpers;

[HtmlTargetElement("ds-container")]
public sealed class ContainerTagHelper : TagHelper
{
    [HtmlAttributeName("class")]
    public string Classes { get; set; } = string.Empty;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";

        var classValue = string.Join(
            " ",
            new[]
            {
                "rtds-container",
                Classes,
            }.Where(static value => !string.IsNullOrWhiteSpace(value))
        );

        output.Attributes.SetAttribute("class", classValue);
    }
}
