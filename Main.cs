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
    }
}
