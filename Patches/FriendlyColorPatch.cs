using HarmonyLib;
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
			Agent main = Agent.Main;

			if (Mission.Current == null || affector == null || affected == null)
			{
				__result = Color.Black;
				return false;
			}

			if (Mission.Current.IsFieldBattle)
			{
				if (affector.Team.IsPlayerTeam)
					__result = Main.GREEN;
				else
					__result = Main.GOODPURPLE;
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
