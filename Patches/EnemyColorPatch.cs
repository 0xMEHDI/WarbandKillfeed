using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "enemyColor", MethodType.Getter)]
	internal class EnemyColorPatch
	{
		public static bool Prefix(ref Color __result)
		{
			Agent affector = OnAgentRemovedPatch.affector;
			Agent affected = OnAgentRemovedPatch.affected;

			if (Mission.Current.IsFieldBattle)
			{
				if (affected.Team.IsPlayerTeam)
				{
					if (affected.State == AgentState.Killed)
						__result = Main.RED;
					else
						__result = Main.ORANGE;
				}

				else
					__result = Main.BADPURPLE;
			}

			else
				__result = !affector.IsEnemyOf(Agent.Main) ? Main.GREEN : (!affected.IsEnemyOf(Agent.Main) ? Main.RED : Main.BADPURPLE);

			return false;
		}
	}
}
