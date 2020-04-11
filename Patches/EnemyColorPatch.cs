using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "enemyColor", MethodType.Getter)]
	internal class EnemyColorPath
	{
		public static bool Prefix(ref Color __result)
		{
			__result = OnAgentRemovedPatch.isAlly ? new Color(0.6f, 0.2f, 0.6f) : (OnAgentRemovedPatch.isUnconscious ? new Color(1f, 0.6f, 0f) : new Color(0.8f, 0f, 0f));
			return false;
		}
	}
}
