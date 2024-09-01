using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Extensions;
using ArchUnitNET.Fluent.Syntax.Elements;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace BridgingTheGap.Architecture.Tests;

public class ProjectDependencies
{
    private static readonly ArchUnitNET.Domain.Architecture Architecture = new ArchLoader().LoadAssemblies(
        typeof(global::BridgingTheGap.Core.DependencyInjectionExtensions).Assembly,
        typeof(global::BridgingTheGap.Data.DependencyInjectionExtensions).Assembly,
        typeof(global::BridgingTheGap.Api.Models.ApiErrorResponse).Assembly,
        typeof(global::BridgingTheGap.Abstractions.HandlerResult<>).Assembly
    ).Build();

    [Fact]
    public void TestThatTheCoreLayerHasNoDependencyToDataEntities()
    {
        var coreNamespace = "BridgingTheGap.Core";
        var dataNamespace = "BridgingTheGap.Data";

        IObjectProvider<IType> coreClasses = Classes().That().ResideInNamespace(coreNamespace, true);
        IObjectProvider<IType> dataEntities = Classes().That().ResideInNamespace(dataNamespace, true)
            .And().HaveNameEndingWith("Entity");

        var rule = Classes(true).That().ResideInNamespace(coreNamespace, true)
            .Should().NotDependOnAny(dataEntities);

        rule.Check(Architecture);
    }

    [Fact]
    public void TestThatTheApiLayerHasNoProjectDependencies()
    {
        var apiNamespace = "BridgingTheGap.Api";

        var rule = Classes(true).That().ResideInNamespace(apiNamespace, true)
            .Should().OnlyDependOnTypesThat().ResideInNamespace(apiNamespace, true);

        rule.Check(Architecture);
    }
}