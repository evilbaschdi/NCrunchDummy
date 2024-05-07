using AutoFixture.Idioms;
using AutoFixture.Xunit2;
using FluentAssertions;
using Xunit;

namespace NCrunchDummy.Lib.Tests;

public class DummyEntityTests
{
    [Theory, AutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DummyEntity).GetConstructors());
    }

    [Theory, AutoData]
    public void Constructor_ReturnsInterfaceName(DummyEntity sut)
    {
        sut.Should().BeAssignableTo<IDummyEntity>();
    }

    [Theory, AutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(DummyEntity).GetMethods().Where(method => !method.IsAbstract));
    }

    [Theory, AutoData]
    public void Value_WithoutCondition_ReturnsEntityWithAttributes(
        DummyEntity sut)
    {
        // Arrange

        // Act
        var result = sut.Value;

        // Assert
        result.LogicalName.Should().Be("dummy");
        result.Attributes.Should().HaveCount(3);
        result.Attributes.Should().HaveElementAt(0, new KeyValuePair<string, object>("title", "ncrunch"));
        result.Attributes.Should().HaveElementAt(1, new KeyValuePair<string, object>("version", "v5"));
        result.Attributes.Should().HaveElementAt(2, new KeyValuePair<string, object>("net", "8.0"));
    }
}