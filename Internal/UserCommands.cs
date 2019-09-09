using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Web;
using DSharpPlus.VoiceNext;

namespace ciscobot.Internal
{
    public class UserCommands
    {
        [Command("iam")]
        public async Task SetRole(CommandContext ctx, string role)
        {
            /**
             * 363121867428462603 - 34
             * 391472844154077195 - 12
             * 403348339040452609 - cst
             */
            var server = ctx.Guild;
            switch (role)
            {
                case "1-2":
                    await ctx.Member.GrantRoleAsync(server.GetRole(391472844154077195));
                    break;
                case "3-4":
                    await ctx.Member.GrantRoleAsync(server.GetRole(363121867428462603));
                    break;
                case "cst":
                    await ctx.Member.GrantRoleAsync(server.GetRole(403348339040452609));
                    break;
                default:
                    break;
            }

            await ctx.Message.DeleteAsync();
        }
    }
}