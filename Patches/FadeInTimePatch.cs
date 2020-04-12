using HarmonyLib;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.KillFeed;

namespace WarbandKillfeed.Patches
{
	[HarmonyPatch(typeof(SingleplayerGeneralKillFeedItemWidget), "FadeInTime", MethodType.Getter)]
	internal class FadeInTimePatch
	{
		public static bool Prefix(ref float __result)
		{
			__result = 0.7f;
			return false;
		}
	}
}
