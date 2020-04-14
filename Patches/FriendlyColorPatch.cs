using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "friendlyColor", MethodType.Getter)]
	internal class FriendlyColorPatch
	{
		public static bool Prefix(ref Color __result)
		{
			Agent affector = OnAgentRemovedPatch.affector;
			Agent affected = OnAgentRemovedPatch.affected;

			if (Mission.Current.IsFieldBattle)
			{
				if (affector.Team.IsPlayerTeam)
					__result = Main.GREEN;
				else
					__result = Main.GOODPURPLE;
			}

			else
				__result = !affector.IsEnemyOf(Agent.Main) ? Main.GREEN : (!affected.IsEnemyOf(Agent.Main) ? Main.RED : Main.BADPURPLE);

			return false;
		}
	}
}
