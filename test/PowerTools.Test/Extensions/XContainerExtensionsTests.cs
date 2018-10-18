﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Xml.Linq;
using Xunit;

namespace Microsoft.DbContextPackage.Extensions
{
    public class XContainerExtensionsTests
    {
        public XContainerExtensionsTests()
        {
            _element1 = new XElement(_ns1 + _elementName);
            _container = new XElement(
                "Container",
                new XElement(_elementName),
                _element1,
                new XElement(_ns2 + _elementName));
        }

        private const string _elementName = "Element";
        private readonly XNamespace _ns1 = "http://tempuri.org/1";
        private readonly XNamespace _ns2 = "http://tempuri.org/2";
        private readonly XElement _element1;
        private readonly XContainer _container;

        [Fact]
        public void Element_returns_first_match()
        {
            var element = _container.Element(
                new[] {_ns1, _ns2},
                _elementName);

            Assert.Same(_element1, element);
        }

        [Fact]
        public void Element_returns_null_when_no_match()
        {
            XNamespace ns3 = "http://tempuri.org/3";

            var element = _container.Element(
                new[] {ns3},
                _elementName);

            Assert.Null(element);
        }
    }
}