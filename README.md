# Judgment Text Changer (Updated)

A [A Dance of Fire and Ice](https://store.steampowered.com/app/977950/) mod for
[Unity Mod Manager](https://www.nexusmods.com/site/mods/21) that lets you replace
the hit-judgment text (Perfect / Early / Late …) with your own custom text.

This is an updated rebuild of the original **Judgment Text Changer** by *Dwenjang*,
fixed to work on current ADOFAI versions.

[中文说明见下方](#中文说明)

---

## Why the old mod broke

The old mod patched `scrHitTextMesh.Init` and wrote the text through the old
`UnityEngine.TextMesh` component. Newer ADOFAI versions changed that component to
**`TMPro.TextMeshPro`**, so the old patch threw and silently did nothing.

The method name `Init`, the `hitMargin` field and the `HitMargin` enum are all
unchanged — only the text component type changed. This build sets the text on the
`TextMeshPro` component instead.

## Features

- Override any of the 7 timing judgments: Too Early, Very Early, Early Perfect,
  Perfect, Late Perfect, Very Late, Too Late. Each field is pre-filled with the
  default judgment text — edit it to taste.
- Leave a field blank to hide that judgment's text entirely (show nothing).
- In-game settings UI with a **中文 / English** language switch.
- Settings persist to `Settings.xml` via UMM.

## Build

### Windows (Visual Studio)
Open `JudgmentTextChanger.csproj`, fix the `<Managed>` path to your game's
`...\A Dance of Fire and Ice_Data\Managed` folder, and build.

### Linux (mono)
```bash
sudo apt install -y mono-mcs
./build-linux.sh        # edit MANAGED path inside if needed
```

## Install

Copy `JudgmentTextChanger.dll` and `Info.json` into:
```
<game>/Mods/JudgmentTextChanger/
```
Launch the game, open UMM (`Ctrl+F10`), pick **Judgment Text Changer**, type your
text per judgment, and click **Save**.

---

## 中文说明

更改 ADOFAI 判定文字（Perfect / Early / Late 等）的 Mod，基于 *Dwenjang* 的原版
**Judgment Text Changer** 修复重制，适配新版游戏。

**旧版为什么失效**：旧 Mod 通过老式 `UnityEngine.TextMesh` 设置文字，新版游戏把
判定文字组件换成了 `TMPro.TextMeshPro`，旧补丁因此抛异常失效。方法 `Init`、字段
`hitMargin`、枚举 `HitMargin` 都没变，本版改为操作 `TextMeshPro` 组件。

**功能**：自定义 7 个判定文字（输入框已预填默认文字，可直接修改）；某个框留空 =
该判定不显示任何文字；界面支持 **中文 / English** 切换；设置自动保存。

> 注：「太快！」「太慢！」各有两档——`Too Early/Very Late` 与 `Very Early/Too Late`，
> 区别在于是否走到了下一个格子，可在界面标签中看到说明。

**安装**：把 `JudgmentTextChanger.dll` 和 `Info.json` 放进 `<游戏目录>/Mods/JudgmentTextChanger/`，
进游戏按 `Ctrl+F10` 打开 UMM，选 **Judgment Text Changer** 填字、点 Save。

## Credits

- Original author: **Dwenjang**
- Updated for current versions by the contributors of this repo.
