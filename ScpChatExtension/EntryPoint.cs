using Exiled.API.Features;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using MEC;
using PlayerRoles;
using Random = UnityEngine.Random;
using Server = Exiled.Events.Handlers.Server;

namespace ScpChatExtension;

public class EntryPoint : Plugin<PluginConfig>
{
    public override string Author { get; } = "jonny02 (original by Jesus-QC and warden161)";
    public override string Name { get; } = "ScpChatExtensions";
    public override Version RequiredExiledVersion { get; } = new(7, 0, 0);
    public override Version Version { get; } = new(1, 2, 0);

    public static Harmony HarmonyPatcher { get; private set; }
    public static List<ReferenceHub> ProximityToggled { get; set; } = new List<ReferenceHub>();
    public const string HarmonyId = "com.warden161.chatextensions";
    public static PluginConfig PluginConfig;

    public override void OnEnabled()
    {
        PluginConfig = Config;
        HarmonyPatcher = new(HarmonyId);
        HarmonyPatcher.PatchAll();

        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        PluginConfig = null;
        HarmonyPatcher.UnpatchAll(HarmonyId);
        HarmonyPatcher = null;
        
      
        base.OnDisabled();
    }

}
