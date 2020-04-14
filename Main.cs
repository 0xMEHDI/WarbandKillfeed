using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using HarmonyLib;

namespace WarbandKillfeed
{
    public class Main : MBSubModuleBase
    {
        private bool isLoaded = false;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            Harmony harmony = new Harmony("mehdi.warbandkillfeed.patch");
            harmony.PatchAll();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (!isLoaded)
            {
                InformationManager.DisplayMessage(new InformationMessage("Loaded Warband Killfeed", Color.FromUint(4281584691)));
                isLoaded = true;
            }
        }

        public static readonly Color GREEN = new Color(0.2f, 0.6f, 0.2f);
        public static readonly Color RED = new Color(0.8f, 0f, 0f);
        public static readonly Color ORANGE = new Color(1f, 0.6f, 0f);
        public static readonly Color GOODPURPLE = new Color(0.4f, 0f, 0.8f);
        public static readonly Color BADPURPLE = new Color(0.4f, 0f, 0.2f);
    }
}
