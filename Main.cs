using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace WarbandKillFeed
{
    public class Main : MBSubModuleBase
    {
        private bool isLoaded = false;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            Harmony harmony = new Harmony("improvedlogs.killfeed.patch");
            harmony.PatchAll();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (!isLoaded)
            {
                InformationManager.DisplayMessage(new InformationMessage("Loaded Warband Kill Feed", Color.FromUint(4281584691)));
                isLoaded = true;
            }
        }
    }
}
