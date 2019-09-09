using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Web;
namespace ciscobot.Internal
{
    public class OwnerCommands
    {
        [Command("getroles")]
        [RequireOwner]
        public async Task GetRoles(CommandContext ctx)
        {
            string output = "```\n";
            string coutput = "```\n";

            foreach (var role in ctx.Guild.Roles)
            {
                output += $"{role.Id}\n";
                coutput += $"{role.Name} - {role.Id}\n";
            }

            output += "```";
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Role Addition";
            embed.Description = output;
            var embedO = embed.Build();
            await ctx.RespondAsync("", false, embedO);
            Console.Write(coutput);
        }

        [Command("shutdown")]
        [RequireOwner]
        public async Task Shutdown(CommandContext ctx)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder();
            embed.Title = "Shutdown";
            embed.Description = "Bot is shutting down with exit code 0";
            embed.Color = DiscordColor.Red;
            var embedO = embed.Build();
            await ctx.RespondAsync("", false, embedO);
            Environment.Exit(0);
        }

        [Command("setgame")]
        [RequireOwner]
        public async Task S(CommandContext ctx, [RemainingText] string game)
        {
            await ctx.Client.UpdateStatusAsync(new DiscordGame(game));
            await ctx.RespondAsync($"Set game to {game}");
            Environment.Exit(0);
        }
    }
}