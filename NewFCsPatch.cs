using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using UnityEngine;
using UnityEngine.PlayerLoop;
using TMPro;

namespace NewFCs
{
    [HarmonyPatch(typeof(DomeHud))]
    public class NewFCsPatch
    {
        static PlayState pState;
        [HarmonyPatch("Init")]
        [HarmonyPostfix]
        public static void InitPatch(ref PlayState playState) {
            pState = playState;
        }

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        public static void UpdatePatch() {
            if (pState.fullComboState == FullComboState.Great ) {
                TMP_Text[] array = pState.Hud.fcTexts;
                for (int i = 0; i < array.Length; i++) {
                    array[i].text = "GFC+";
                }
            }
            else if (pState.fullComboState == FullComboState.Good) {
                TMP_Text[] array = pState.Hud.fcTexts;
                for (int i = 0; i < array.Length; i++) {
                    array[i].text = "GFC";
                }
            }
            else if (pState.fullComboState == FullComboState.PerfectPlus) {
                TMP_Text[] array = pState.Hud.fcTexts;
                for (int i = 0; i < array.Length; i++) {
                    array[i].text = "PFC+";
                }
            }
            
        }

    }
}
