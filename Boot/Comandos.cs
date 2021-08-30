using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Boot
{
    
        public class Comandos0 : ModuleBase<SocketCommandContext>
        {
            [Command("+=")]
            public async Task comandos(int somar1, int somar2)
            {
       
                await ReplyAsync($"Eu acho q o resultado é: {somar1 + somar2} marre certeza não confia quem quer");

        }

        }

        public class Comandos01 : ModuleBase<SocketCommandContext>
        {
            [Command("-=")]
            public async Task comandos(int somar1, int somar2)
            {

                await ReplyAsync($"Eu acho q o resultado é: {somar1 - somar2} marre certeza não confia quem quer");

            }

        }

        public class Comandos03 : ModuleBase<SocketCommandContext>
        {
            [Command("*=")]
            public async Task comandos(int somar1, int somar2)
            {

                await ReplyAsync($"Eu acho q o resultado é: {somar1 * somar2} marre certeza não confia quem quer");

            }

        }

        public class Comandos04 : ModuleBase<SocketCommandContext>
        {
            [Command("/=")]
            public async Task comandos(int somar1, int somar2)
            {

                await ReplyAsync($"Eu acho q o resultado é: {somar1 / somar2} marre certeza não confia quem quer");

            }

        }

    }

}
