using System.Xml.Serialization;
using UnityModManagerNet;

namespace JudgmentTextChanger
{
    // 用 UMM 自带的 ModSettings：自动以 XML 形式存到 Mods/JudgmentTextChanger/Settings.xml
    public class Settings : UnityModManager.ModSettings
    {
        // Mod 界面语言：0 = 中文，1 = English
        public int Language = 0;

        // 默认值 = 游戏内显示的判定文字。把某个框清空 = 该判定不显示任何文字。
        // 注意 TooEarly/VeryEarly 都显示「太快！」，TooLate/VeryLate 都显示「太慢！」，
        // 区别在于是否走到了下一个格子（详见界面标签）。
        public string TooEarly     = "太快！";
        public string VeryEarly    = "太快！";
        public string EarlyPerfect = "稍快！";
        public string Perfect      = "完美！";
        public string LatePerfect  = "稍慢！";
        public string VeryLate     = "太慢！";
        public string TooLate      = "太慢！";

        // 根据 HitMargin 取出对应文字。
        //   返回 ""   = 该框留空，表示不显示判定文字（补丁会把文本设成空串）
        //   返回 null = 这是我们不处理的判定（如 Miss 等），补丁保持游戏原样
        public string GetText(HitMargin margin)
        {
            switch (margin)
            {
                case HitMargin.TooEarly:     return TooEarly     ?? "";
                case HitMargin.VeryEarly:    return VeryEarly    ?? "";
                case HitMargin.EarlyPerfect: return EarlyPerfect ?? "";
                case HitMargin.Perfect:      return Perfect      ?? "";
                case HitMargin.LatePerfect:  return LatePerfect  ?? "";
                case HitMargin.VeryLate:     return VeryLate     ?? "";
                case HitMargin.TooLate:      return TooLate      ?? "";
                default:                     return null;
            }
        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }
    }
}
