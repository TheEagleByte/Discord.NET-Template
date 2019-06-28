using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Template.Modules
{
    [Name("Management")]
    [Summary("Management Commands")]
    public class ManagementModule : ModuleBase<SocketCommandContext>
    {
        [Command("purge", RunMode = RunMode.Async)]
        [Summary("Deletes the specified amount of messages.")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]
        public async Task PurgeChat([Summary("Number of messages to purge in this channel")] int amount)
        {
            var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten().ToList();

            foreach (var message in messages)
            {
                await Context.Channel.DeleteMessageAsync(message);
            }

            const int delay = 5000;
            var m = await ReplyAsync($"Purge completed. _This message will be deleted in {delay / 1000} seconds._");
            await Task.Delay(delay);
            await m.DeleteAsync();
        }
    }
}
