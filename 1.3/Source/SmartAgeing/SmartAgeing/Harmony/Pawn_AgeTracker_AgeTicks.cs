using HarmonyLib;
using RimWorld;
using Verse;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection.Emit;



namespace SmartAgeing
{


    [HarmonyPatch(typeof(Pawn_AgeTracker))]
    [HarmonyPatch("AgeTick")]
    public static class SmartAgeing_Pawn_AgeTracker_AgeTick_Patch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {


            var codes = instructions.ToList();
         
            for (var i = 0; i < codes.Count; i++)
            {
                

                if (codes[i].opcode == OpCodes.Ldc_I4 && (int)(codes[i].operand) == 3600000)
                {
                   
                    yield return new CodeInstruction(OpCodes.Ldc_I4,360);
                }
                
                else
                {
                    yield return codes[i];
                }


            }


        }
    }
}