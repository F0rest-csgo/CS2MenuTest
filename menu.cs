using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Cvars;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Memory;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Timers;
using CounterStrikeSharp.API.Modules.Utils;

namespace test
{
    class test:BasePlugin
    {
        private void SetupMenus()
        {
            // Chat Menu Example

            var giveItemMenu = new ChatMenu("Gun Menu");
            var handleGive = (CCSPlayerController player, ChatMenuOption option) =>
            {
                player.GiveNamedItem(option.Text);
                player.PrintToChat($"You've been given a {option.Text}");
            };//定义handleGive Handle(Action)

            giveItemMenu.AddMenuOption("weapon_ak47", handleGive);
            giveItemMenu.AddMenuOption("weapon_awp", handleGive);
            giveItemMenu.AddMenuOption("weapon_p250", handleGive);
            AddCommand("css_gunmenu", "Gun Menu", (player, info) => { ChatMenus.OpenMenu(player, giveItemMenu); });//输入css_gunmenu的Action：为player打开一个giveItemMenu

            for (int i = 1; i <= 9; i++)
            {
                AddCommand("css_" + i, "Command Key Handler", (player, info) =>
                {
                    if (player == null) return;
                    var key = Convert.ToInt32(info.GetArg(0).Split("_")[1]);//GetArg(0)==css_<i>,Split[1]==(string)<i>,ToInt32==(int)<i>
                    ChatMenus.OnKeyPress(player, key);//key是int值（不明白为什么一定要onkeypress是个int
                });//其实这个定义handler指令的应该是css自带的吧
            }
        }
    }
}