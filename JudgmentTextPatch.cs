using System.Reflection;
using HarmonyLib;
using TMPro;

namespace JudgmentTextChanger
{
    // 旧版游戏用 UnityEngine.TextMesh，新版改成了 TMPro.TextMeshPro，
    // 这也是旧 Mod 失效的原因。这里在 Init 之后把已经本地化好的判定文字替换掉。
    [HarmonyPatch(typeof(scrHitTextMesh), "Init")]
    internal static class JudgmentTextPatch
    {
        // text 字段是私有的 TMPro.TextMeshPro，用 AccessTools 拿（私有也能取）
        private static readonly FieldInfo fText =
            AccessTools.Field(typeof(scrHitTextMesh), "text");

        // Init(HitMargin hitMargin) —— Postfix 可以直接拿到参数 hitMargin
        private static void Postfix(scrHitTextMesh __instance, HitMargin hitMargin)
        {
            if (Main.settings == null) return;

            string custom = Main.settings.GetText(hitMargin);
            if (custom == null) return; // 不是我们处理的判定（如 Miss），保持游戏原样

            // custom 为 "" 时表示该判定不显示任何文字
            var tmp = fText.GetValue(__instance) as TMP_Text;
            if (tmp != null)
                tmp.text = custom;
        }
    }
}
