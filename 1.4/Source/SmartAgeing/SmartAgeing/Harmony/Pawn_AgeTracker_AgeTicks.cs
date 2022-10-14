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
        static void DoBirthdays(Pawn_AgeTracker __instance,Pawn ___pawn)
        {
            if (!___pawn.def.race.Animal)
            {
                if (Find.TickManager.TicksGame % (3600000 / SmartAgeing_Settings.ageingRate) == 0)
                {
                    if (SmartAgeing_Settings.applyOldAgeDiseases)
                    {
                        MethodInfo birthday = AccessTools.Method(typeof(Pawn_AgeTracker), "BirthdayBiological");
                        birthday.Invoke(__instance, null);
                    }
                    MethodInfo growth = AccessTools.Method(typeof(Pawn_AgeTracker), "CalculateGrowth");
                    growth.Invoke(__instance, new object[] {(int)(240* SmartAgeing_Settings.ageingRate) });
                }
            }
            else
            {
                if (SmartAgeing_Settings.affectAnimals)
                {

                    if (Find.TickManager.TicksGame % (3600000 / SmartAgeing_Settings.animalAgeingRate) == 0)
                    {
                        if (SmartAgeing_Settings.applyOldAgeDiseases)
                        {
                            MethodInfo birthday = AccessTools.Method(typeof(Pawn_AgeTracker), "BirthdayBiological");
                            birthday.Invoke(__instance, null);
                        }
                        MethodInfo growth = AccessTools.Method(typeof(Pawn_AgeTracker), "CalculateGrowth");
                        growth.Invoke(__instance, new object[] { (int)(240 * SmartAgeing_Settings.ageingRate) });
                    }
                }
            }       
        }
    }

    [HarmonyPatch(typeof(Pawn_AgeTracker))]
    [HarmonyPatch("AgeTick")]
    public static class SmartAgeing_Pawn_AgeTracker_AgeTick_Prefix
    {
        [HarmonyPrefix]
        static void AgeTickIncrease(ref long ___ageBiologicalTicksInt, ref long ___birthAbsTicksInt, Pawn ___pawn)
        {


            if (!___pawn.def.race.Animal)
            {
                ___ageBiologicalTicksInt += SmartAgeing_Settings.ageingRate - 1;
                ___birthAbsTicksInt -= (SmartAgeing_Settings.ageingRate - 1);
            }
            else
            {
                if (SmartAgeing_Settings.affectAnimals)
                {

                    ___ageBiologicalTicksInt += SmartAgeing_Settings.animalAgeingRate - 1;
                    ___birthAbsTicksInt -= (SmartAgeing_Settings.animalAgeingRate - 1);
                }
            }

         } 
    }
}