#!/usr/bin/env bash
# 在 Ubuntu 上用 mono 的 C# 编译器(mcs)编译本 Mod。
# 首次使用先装编译器：  sudo apt install -y mono-mcs
set -e
cd "$(dirname "$0")"
MANAGED="../A Dance of Fire and Ice/A Dance of Fire and Ice_Data/Managed"

mcs -target:library -out:JudgmentTextChanger.dll \
  -r:"$MANAGED/UnityModManager/UnityModManager.dll" \
  -r:"$MANAGED/UnityModManager/0Harmony.dll" \
  -r:"$MANAGED/Assembly-CSharp.dll" \
  -r:"$MANAGED/RDTools.dll" \
  -r:"$MANAGED/DOTween.dll" \
  -r:"$MANAGED/Unity.TextMeshPro.dll" \
  -r:"$MANAGED/UnityEngine.UI.dll" \
  -r:"$MANAGED/UnityEngine.dll" \
  -r:"$MANAGED/UnityEngine.TextCoreFontEngineModule.dll" \
  -r:"$MANAGED/UnityEngine.TextCoreTextEngineModule.dll" \
  -r:"$MANAGED/UnityEngine.CoreModule.dll" \
  -r:"$MANAGED/UnityEngine.IMGUIModule.dll" \
  -r:"$MANAGED/UnityEngine.TextRenderingModule.dll" \
  -r:"$MANAGED/netstandard.dll" \
  Main.cs Settings.cs JudgmentTextPatch.cs

echo "✓ 编译完成: JudgmentTextChanger.dll"
echo "把 JudgmentTextChanger.dll 和 Info.json 一起放到 Mods/JudgmentTextChanger/ 即可"
