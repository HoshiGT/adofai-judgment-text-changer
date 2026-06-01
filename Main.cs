using System.Reflection;
using HarmonyLib;
using UnityEngine;
using UnityModManagerNet;

namespace JudgmentTextChanger
{
    public static class Main
    {
        public static UnityModManager.ModEntry mod;
        public static Settings settings;
        private static Harmony harmony;

        // 界面语言文案：[中文, English]
        private static readonly string[] LangNames = { "中文", "English" };
        private static readonly string[] Hint =
        {
            "留空 = 保持游戏原文。修改后请点击下方 Save 保存。",
            "Leave blank = keep the game's original text. Click Save below after editing."
        };
        private static readonly string[] LangLabel = { "界面语言", "Language" };
        // 7 个判定的标签：第 0 列中文，第 1 列英文
        private static readonly string[,] Labels =
        {
            { "太早 (Too Early)",      "Too Early" },
            { "稍早 (Very Early)",     "Very Early" },
            { "偏早完美 (EarlyPerfect)","Early Perfect" },
            { "完美 (Perfect)",        "Perfect" },
            { "偏晚完美 (LatePerfect)", "Late Perfect" },
            { "稍晚 (Very Late)",      "Very Late" },
            { "太晚 (Too Late)",       "Too Late" },
        };

        // EntryMethod = JudgmentTextChanger.Main.Load
        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            mod = modEntry;
            settings = UnityModManager.ModSettings.Load<Settings>(modEntry);

            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;

            return true;
        }

        // 开/关 Mod 时挂载或卸载 Harmony 补丁
        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value)
            {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            else
            {
                harmony?.UnpatchAll(modEntry.Info.Id);
                harmony = null;
            }
            return true;
        }

        private static int Lang => (settings.Language == 1) ? 1 : 0;

        private static void Row(int index, ref string field)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(Labels[index, Lang], GUILayout.Width(180));
            field = GUILayout.TextField(field ?? "", GUILayout.Width(220));
            GUILayout.EndHorizontal();
        }

        private static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            // 语言切换
            GUILayout.BeginHorizontal();
            GUILayout.Label(LangLabel[Lang], GUILayout.Width(180));
            settings.Language = GUILayout.Toolbar(Lang, LangNames, GUILayout.Width(220));
            GUILayout.EndHorizontal();

            GUILayout.Space(4);
            GUILayout.Label(Hint[Lang]);
            GUILayout.Space(6);

            Row(0, ref settings.TooEarly);
            Row(1, ref settings.VeryEarly);
            Row(2, ref settings.EarlyPerfect);
            Row(3, ref settings.Perfect);
            Row(4, ref settings.LatePerfect);
            Row(5, ref settings.VeryLate);
            Row(6, ref settings.TooLate);
        }

        private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            settings.Save(modEntry);
        }
    }
}
