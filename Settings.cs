using System.Xml.Serialization;
using UnityModManagerNet;

namespace JudgmentTextChanger
{
    // 用 UMM 自带的 ModSettings：自动以 XML 形式存到 Mods/JudgmentTextChanger/Settings.xml
    public class Settings : UnityModManager.ModSettings
    {
        // Mod 界面语言：0 = 中文，1 = English
        public int Language = 0;

        // 留空 = 不修改该判定，保持游戏原文（本地化文本）
        public string TooEarly     = "";
        public string VeryEarly    = "";
        public string EarlyPerfect = "";
        public string Perfect      = "";
        public string LatePerfect  = "";
        public string VeryLate     = "";
        public string TooLate      = "";

        // 根据 HitMargin 取出对应的自定义文字；没设置就返回 null
        public string GetText(HitMargin margin)
        {
            string s = null;
            switch (margin)
            {
                case HitMargin.TooEarly:     s = TooEarly;     break;
                case HitMargin.VeryEarly:    s = VeryEarly;    break;
                case HitMargin.EarlyPerfect: s = EarlyPerfect; break;
                case HitMargin.Perfect:      s = Perfect;      break;
                case HitMargin.LatePerfect:  s = LatePerfect;  break;
                case HitMargin.VeryLate:     s = VeryLate;     break;
                case HitMargin.TooLate:      s = TooLate;      break;
            }
            return string.IsNullOrEmpty(s) ? null : s;
        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }
    }
}
