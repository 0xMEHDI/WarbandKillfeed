using HarmonyLib;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SingleplayerGeneralKillFeedItemWidget), "StayTime", MethodType.Getter)]
	internal class StayTimePatch
	{
		public static bool Prefix(ref float __result)
		{
			__result = 5f;
			return false;
		}
	}
}
