using System.Reflection;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Spt.Mod;
using WTTServerCommonLib.Models;
using Range = SemanticVersioning.Range;
using EcoWW2Pack.Helpers;

namespace EcoWW2Pack;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.wtt.ecoww2pack";
    public override string Name { get; init; } = "Eco-WW2-Pack";
    public override string Author { get; init; } = "Eco";
    public override List<string>? Contributors { get; init; } = null;
    public override SemanticVersioning.Version Version { get; init; } = new(typeof(ModMetadata).Assembly.GetName().Version?.ToString(3));
    public override Range SptVersion { get; init; } = new("~4.0.13");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, Range>? ModDependencies { get; init; } = new()
    {
        { "com.wtt.commonlib", new Range("~2.0.18") }
    };
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; } = true;
    public override string License { get; init; } = "MIT";
}


[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 2)]
public class EcoWW2Pack(
    WTTServerCommonLib.WTTServerCommonLib wttCommon,
    EcoQuestHelper ecoQuestHelper) : IOnLoad
{
    public async Task OnLoad()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        await wttCommon.CustomItemServiceExtended.CreateCustomItems(assembly);
        await wttCommon.CustomBotLoadoutService.CreateCustomBotLoadouts(assembly);
        await wttCommon.CustomAssortSchemeService.CreateCustomAssortSchemes(assembly);
        ecoQuestHelper.ModifyQuests();
        await Task.CompletedTask;
    }
}
