// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Lycopersicon_src.Brain;
using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Schema;

namespace AspNetCore_EchoBot_With_State
{
    public class EchoBot : IBot
    {
        /// <summary>
        /// Every Conversation turn for our EchoBot will call this method. In here
        /// the bot checks the Activty type to verify it's a message, bumps the 
        /// turn conversation 'Turn' count, and then echoes the users typing
        /// back to them. 
        /// </summary>
        /// <param name="context">Turn scoped context containing all the data needed
        /// for processing this conversation turn. </param>        
        public async Task OnTurn(ITurnContext context)
        {
            // This bot is only handling Messages
            if (context.Activity.Type == ActivityTypes.Message)
            {
                // Get the conversation state from the turn context
                var state = context.GetConversationState<EchoState>();

                // Bump the turn count. 
                //brain.memory.Change("TurnCount","++");
                state.TurnCount++;

                // Call brain to respond
                var response = state.Brain.respond(context.Activity.Text);
                bool echoDebug = false;
                if (echoDebug) {
                    response = $"{state.TurnCount}: You wrote: {context.Activity.Text}.";
                    await context.SendActivity(response);
                }
                //brain.respond(context.Activity.Text);

                // Echo back to the user whatever they typed.
                await context.SendActivity(response);
            }
        }
    }    
}
