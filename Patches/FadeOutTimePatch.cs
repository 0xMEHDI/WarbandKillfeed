using HarmonyLib;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.KillFeed;

namespace WarbandKillfeed.Patches
{
	[HarmonyPatch(typeof(SingleplayerGeneralKillFeedItemWidget), "FadeOutTime", MethodType.Getter)]
	internal class FadeOutTimePatch
	{
		public static bool Prefix(ref float __result)
		{
			__result = 0.7f;
			return false;
		}
	}
}
