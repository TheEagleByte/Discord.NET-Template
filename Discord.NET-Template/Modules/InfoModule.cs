﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Template.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("info")]
        [Alias("about")]
        public async Task InfoAsync()
        {
            var app = await Context.Client.GetApplicationInfoAsync();

            await ReplyAsync(
                $"{Format.Bold("Info")}\n" +
                $"- Author: {app.Owner} ({app.Owner.Id})\n" +
                $"- Library: Discord.Net ({DiscordConfig.Version})\n" +
                $"- Runtime: {RuntimeInformation.FrameworkDescription} {RuntimeInformation.ProcessArchitecture} " +
                $"({RuntimeInformation.OSDescription} {RuntimeInformation.OSArchitecture})\n" +
                $"- Up Time: {GetUpTime()}\n\n" +

                $"{Format.Bold("Stats")}\n" +
                $"- Heap Size: {GetHeapSize()}MiB\n" +
                $"- Guilds: {Context.Client.Guilds.Count}\n" +
                $"- Channels: {Context.Client.Guilds.Sum(g => g.Channels.Count)}\n" +
                $"- Users: {Context.Client.Guilds.Sum(g => g.Users.Count)}\n");
        }

        private static string GetUpTime() => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm\:ss");
        private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString(CultureInfo.InvariantCulture);
    }
}
