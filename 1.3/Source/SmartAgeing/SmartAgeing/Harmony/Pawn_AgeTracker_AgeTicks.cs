using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;



namespace SmartAgeing
{


    [HarmonyPatch(typeof(Pawn_AgeTracker))]
    [HarmonyPatch("AgeTick")]
    public static class SmartAgeing_Pawn_AgeTracker_AgeTick_Postfix
    {

        [HarmonyPostfix]
        static void DoBirthdays(Pawn_AgeTracker __instance)
        {
            if (Find.TickManager.TicksGame % (3600000/SmartAgeing_Settings.ageingRate) == 0)
            {
                MethodInfo birthday = AccessTools.Method(typeof(Pawn_AgeTracker), "BirthdayBiological");
                birthday.Invoke(__instance, null);


            }



        }
    }


    [HarmonyPatch(typeof(Pawn_AgeTracker))]
    [HarmonyPatch("AgeTick")]
    public static class SmartAgeing_Pawn_AgeTracker_AgeTick_Prefix
    {
        [HarmonyPrefix]
        static void AgeTickIncrease(ref long ___ageBiologicalTicksInt, ref long ___birthAbsTicksInt)
        {
            ___ageBiologicalTicksInt += SmartAgeing_Settings.ageingRate - 1;
            ___birthAbsTicksInt -= (SmartAgeing_Settings.ageingRate - 1);

          

        }

       
    }
}