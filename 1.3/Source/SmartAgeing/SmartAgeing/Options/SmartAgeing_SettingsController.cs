using RimWorld;
using UnityEngine;
using Verse;


namespace SmartAgeing
{



    public class SmartAgeing_Mod : Mod
    {


        public SmartAgeing_Mod(ModContentPack content) : base(content)
        {
            GetSettings<SmartAgeing_Settings>();
        }
        public override string SettingsCategory()
        {

            return "Smart Ageing";



        }



        public override void DoSettingsWindowContents(Rect inRect)
        {
            SmartAgeing_Settings.DoWindowContents(inRect);
        }
    }


}
