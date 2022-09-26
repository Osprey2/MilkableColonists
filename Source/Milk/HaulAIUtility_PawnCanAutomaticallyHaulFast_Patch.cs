using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace Milk;

[HarmonyPatch(typeof(HaulAIUtility), "PawnCanAutomaticallyHaulFast")]
public static class HaulAIUtility_PawnCanAutomaticallyHaulFast_Patch
{
    [HarmonyPostfix]
    public static void isMilk(ref Pawn p, ref Thing t, ref bool forced, ref bool __result)
    {
        LocalTargetInfo target = t;
        if (p.CanReserve(target, 1, -1, null, forced) &&
            p.CanReach(t, PathEndMode.ClosestTouch, p.NormalMaxDanger()) && !t.IsBurning() &&
            (t.def == ThingDef.Named("Milk") || t.def == ThingDef.Named("EggChickenUnfertilized")))
        {
            __result = true;
        }
    }
}