using RimWorld;
using UnityEngine;
using Verse;
using System;


namespace SmartAgeing
{


    public class SmartAgeing_Settings : ModSettings

    {



        public static int ageingRate = baseAgeingRate;
        public const int baseAgeingRate = 1;
        public const int maxAgeingRate = 1000;

        public static int animalAgeingRate = baseAnimalAgeingRate;
        public const int baseAnimalAgeingRate = 1;
        public const int maxAnimalAgeingRate = 1000;

        public static bool affectAnimals = true;
        public static bool applyOldAgeDiseases = true;





        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref ageingRate, "ageingRate", baseAgeingRate, true);
            Scribe_Values.Look(ref animalAgeingRate, "animalAgeingRate", baseAnimalAgeingRate, true);

            Scribe_Values.Look(ref affectAnimals, "affectAnimals", true, true);
            Scribe_Values.Look(ref applyOldAgeDiseases, "applyOldAgeDiseases", true, true);




        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls2 = new Listing_Standard();


            ls2.Begin(inRect);
            ls2.CheckboxLabeled("SA_affectAnimals".Translate(), ref affectAnimals, "SA_affectAnimalsTooltip".Translate());
            ls2.CheckboxLabeled("SA_applyOldAgeDiseases".Translate(), ref applyOldAgeDiseases, "SA_applyOldAgeDiseasesTooltip".Translate());


            var ageingRateLabel = ls2.LabelPlusButton("SA_ageingRate".Translate() + ": " + ageingRate, "SA_ageingRateTooltip".Translate());
            ageingRate = (int)Math.Round(ls2.Slider(ageingRate, baseAgeingRate, maxAgeingRate), 0);

            if (ls2.Settings_Button("SA_Reset".Translate(), new Rect(0f, ageingRateLabel.position.y + 35, 250f, 29f)))
            {
                ageingRate = baseAgeingRate;
            }
            var animalAgeingRateLabel = ls2.LabelPlusButton("SA_animalAgeingRate".Translate() + ": " + animalAgeingRate, "SA_animalAgeingRateTooltip".Translate());
            animalAgeingRate = (int)Math.Round(ls2.Slider(animalAgeingRate, baseAnimalAgeingRate, maxAnimalAgeingRate), 0);

            if (ls2.Settings_Button("SA_Reset".Translate(), new Rect(0f, animalAgeingRateLabel.position.y + 35, 250f, 29f)))
            {
                animalAgeingRate = baseAnimalAgeingRate;
            }



            ls2.End();
        }



    }










}
