using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;




namespace Boot
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();

            string tokenBot = "Token";

            _client.Ready += Client_Ready;
            _client.Log += ClientLog;
            _client.UserJoined += userJoined;


            await Client_Ready();
            await ComandosBot();
           
            _client.LoginAsync(TokenType.Bot , tokenBot);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private async Task userJoined(SocketGuildUser user)
        {
            var usuario = user.Guild;
        }

        private Task ClientLog(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        private async Task Client_Ready()
        {
            await _client.SetGameAsync("Filho do Biutec", "https://www.biotec.net.br/", StreamType.NotStreaming);
        }

        public async Task ComandosBot()
        {
            _client.MessageReceived += iniciaComandos;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());

        }

        private async Task iniciaComandos(SocketMessage arg)
        {
            var mensagem = arg as SocketUserMessage;
            if (mensagem is null || mensagem.Author.IsBot) return;

            var Context = new SocketCommandContext(_client, mensagem);
            int argPost = 0;
            if (mensagem.HasStringPrefix("", ref argPost))
            {
                var result = await _commands.ExecuteAsync(Context, argPost);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }


            }


        }




    }
}
