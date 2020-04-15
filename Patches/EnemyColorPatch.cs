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
			Agent main = Agent.Main;

			if (Mission.Current == null || affector == null || affected == null)
			{
				__result = Color.Black;
				return false;
			}

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

			else if (main != null)
			{
				__result = !affector.IsEnemyOf(main) ? Main.GREEN : (!affected.IsEnemyOf(main) ? Main.RED : Main.BADPURPLE);
			}

			else
				__result = Color.Black;

			return false;
		}
	}
}
