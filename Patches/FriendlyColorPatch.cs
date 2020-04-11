using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade.ViewModelCollection.HUD.KillFeed;

namespace WarbandKillfeed
{
	[HarmonyPatch(typeof(SPMissionKillNotificationItemVM), "friendlyColor", MethodType.Getter)]
	internal class FriendlyColorPath
	{
		public static bool Prefix(ref Color __result)
		{
			__result = new Color(0.2f, 0.6f, 0.2f);
			return false;
		}
	}
}
