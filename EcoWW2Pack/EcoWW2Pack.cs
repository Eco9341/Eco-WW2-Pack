using EcoWW2Pack.Helpers;
using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Services;
using System.Reflection;
using WTTServerCommonLib.Helpers;
using WTTServerCommonLib.Models;
using WTTServerCommonLib.Services;
using Range = SemanticVersioning.Range;

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
        { "com.wtt.commonlib", new Range("~2.0.20") }
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
[Injectable(InjectionType.Singleton, TypePriority = OnLoadOrder.PostSptModLoader + 2)]
public class EcoWW2PackPostSptLoad(
    IReadOnlyList<SptMod> modList,
    DatabaseService databaseService,
    SlotHelper slotHelper) : IOnLoad
{
    private static readonly string[] ArmoryAmmoIds =
    [
        "66d0c1319aba7b6bff460a37",
        "682e8c4bc098b59f14dde097",
        "6861847dfd5210a3e64677a3"
    ];

    public Task OnLoad()
    {
        if (!modList.Any(mod => mod.ModMetadata.ModGuid == "com.wtt.armory"))
        {
            return Task.CompletedTask;
        }

        var items = databaseService.GetItems();

        if (items.TryGetValue("6a0ce40499dfd9edaca1daa9", out var kar98))
        {
            AddAmmoToFilter(kar98.Properties.Chambers.FirstOrDefault()?.Properties.Filters.FirstOrDefault()?.Filter);
        }

        if (items.TryGetValue("6a0ced4599dfd9edaca1daaa", out var kar98mag))
        {
            AddAmmoToFilter(kar98mag.Properties.Cartridges.FirstOrDefault()?.Properties.Filters.FirstOrDefault()?.Filter);
        }

        return Task.CompletedTask;
    }

    private static void AddAmmoToFilter(HashSet<MongoId>? filter)
    {
        if (filter == null)
        {
            return;
        }

        foreach (var ammoId in ArmoryAmmoIds)
        {
            if (!filter.Contains(ammoId))
            {
                filter.Add(ammoId);
            }
        }
    }
}