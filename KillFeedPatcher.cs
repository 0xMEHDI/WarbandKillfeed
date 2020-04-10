using System;
using System.Text;
using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.GauntletUI.Widgets.Mission.KillFeed;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPKillFeedVM), "OnAgentRemoved")]
	internal class KillFeedPatch
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

	[HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "friendlyColor", MethodType.Getter)]
	internal class FriendlyColorPath
	{
		public static bool Prefix(ref Color __result)
		{
			__result = new Color(0.2f, 0.6f, 0.2f);
			return false;
		}
	}

	[HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "enemyColor", MethodType.Getter)]
	internal class EnemyColorPath
	{
		public static bool Prefix(ref Color __result)
		{
			__result = KillFeedPatch.isAlly ? new Color(0.6f, 0.2f, 0.6f) : (KillFeedPatch.isUnconscious ? new Color(1f, 0.6f, 0f) : new Color(0.8f, 0f, 0f));
			return false;
		}
	}

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
