// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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

                var question = context.Activity.Text.ToLower();

                // Bump the turn count. 
                state.TurnCount++;

                var response = "..";

                switch (question)
                {
                    case "hello":
                        if (state.greeting)
                        {
                            response = "We've already greeted Today.";
                        }
                        else
                        {
                            response = "Hello!";
                            state.greeting = true;
                        }
                        
                        break;

                    case "bye":
                        if (state.greeting)
                        {
                            response = "Bye!";
                            state.greeting = false;
                        }
                        else
                        {
                            response = "Bye without Hello first?!";
                        }

                        break;

                    default:
                        response = $"Turn {state.TurnCount}: You sent '{context.Activity.Text}'";
                        break;
                }

                // Echo back to the user whatever they typed.
                await context.SendActivity(response);
            }
        }
    }    
}
