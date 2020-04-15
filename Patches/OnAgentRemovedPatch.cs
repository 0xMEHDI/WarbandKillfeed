using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPKillFeedVM), "OnAgentRemoved")]
	internal class OnAgentRemovedPatch
	{
		public static Agent affector;
		public static Agent affected;

		public static bool Prefix(ref Agent affectorAgent, ref Agent affectedAgent)
		{
			if (affectorAgent == null || affectedAgent == null)
				return true;

			affector = affectorAgent;
			affected = affectedAgent;

			return true;
		}
	}
}
