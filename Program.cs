using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using ciscobot.Internal;
using DSharpPlus.VoiceNext;
using System.Timers;
using System.Collections.Generic;
using System.Linq;

namespace ciscobot
{
    class Program
    {
        static CommandsNextModule commands;

        DiscordClient discord;

        private async Task MainAsync(string[] args)
        {
            Config config = new Config();    

            discord = new DiscordClient(new DiscordConfiguration
            {
            Token = config.token,
            TokenType = TokenType.Bot,
            UseInternalLogHandler = true,
            LogLevel = LogLevel.Debug,
            });
            
            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "."
            });
            
            commands.RegisterCommands<UserCommands>();
            commands.RegisterCommands<OwnerCommands>();

            await discord.ConnectAsync();

            await Task.Delay(-1);
        }

        // Main function
        static void Main(string[] args)
        {
            Program self = new Program();
            self.MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
