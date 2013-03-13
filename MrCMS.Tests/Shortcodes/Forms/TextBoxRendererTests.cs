﻿using FluentAssertions;
using MrCMS.Entities.Documents.Web;
using MrCMS.Entities.Documents.Web.FormProperties;
using MrCMS.Shortcodes.Forms;
using Xunit;

namespace MrCMS.Tests.Shortcodes.Forms
{
    public class TextBoxRendererTests
    {
        private TextBoxRenderer _textBoxRenderer;

        public TextBoxRendererTests()
        {
            _textBoxRenderer = new TextBoxRenderer();
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldHaveTagNameOfInput()
        {
            var appendElement = _textBoxRenderer.AppendElement(new TextBox());

            appendElement.TagName.Should().Be("input");
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldHaveTypeOfText()
        {
            var appendElement = _textBoxRenderer.AppendElement(new TextBox());

            appendElement.Attributes["type"].Should().Be("text");
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldHaveNameOfTextBoxName()
        {
            var appendElement = _textBoxRenderer.AppendElement(
                new TextBox {Name = "test name"});

            appendElement.Attributes["name"].Should().Be("test name");
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldSetHtmlIdIfItIsSet()
        {
            var appendElement = _textBoxRenderer.AppendElement(
                new TextBox {HtmlId = "test-id"});

            appendElement.Attributes["id"].Should().Be("test-id");
        }

        [Fact]
        public void TextBoxRenderer_IsSelfClosing_ShouldBeTrue()
        {
            _textBoxRenderer.IsSelfClosing.Should().BeTrue();
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldAppendDataValTrueIfIsRequired()
        {
            var appendElement = _textBoxRenderer.AppendElement(
                new TextBox{Required = true});

            appendElement.Attributes["data-val"].Should().Be("true");
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldAppendDataValRequiredIfIsRequiredUsingTheLabelText()
        {
            var appendElement = _textBoxRenderer.AppendElement(
                new TextBox{Required = true,LabelText = "Test Label"});

            appendElement.Attributes["data-val-required"].Should().Be("The field Test Label is required");
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldAppendDataValRequiredIfIsRequiredUsingTheNameIfLabelTextIsMissing()
        {
            var appendElement = _textBoxRenderer.AppendElement(
                new TextBox{Required = true, Name = "test-name"});

            appendElement.Attributes["data-val-required"].Should().Be("The field test-name is required");
        }

        [Fact]
        public void TextBoxRenderer_AppendElement_ShouldAppendNeitherDataAttributesIfRequiredIsFalse()
        {
            var appendElement = _textBoxRenderer.AppendElement(
                new TextBox{Required = false});

            appendElement.Attributes.ContainsKey("data-val").Should().BeFalse();
            appendElement.Attributes.ContainsKey("data-val-required").Should().BeFalse();
        }
    }
}