using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPKillFeedVM), "OnAgentRemoved")]
	internal class OnAgentRemovedPatch
	{
		public static bool isUnconscious;
		public static bool isAlly;

		public static bool Prefix(ref Agent affectedAgent)
		{
			isUnconscious = affectedAgent.State == AgentState.Unconscious ? true : false;

			if (affectedAgent.Team != null)
				isAlly = (affectedAgent.Team.IsPlayerAlly && !affectedAgent.Team.IsPlayerTeam);

			return true;
		}
	}
}
