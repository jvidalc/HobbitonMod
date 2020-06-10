using Terraria;
using System.Collections.Generic;

namespace HobbitonMod.NPCs.Hobbits
{
    class CustomChats
    {
        public List<string> chatsBilbo { get; }
        public List<string> chatsFrodo { get; }
        public List<string> chatsSam { get; }
        public List<string> chatsMerryPippin { get; }

        public CustomChats()
        {
            chatsBilbo = ChatsBilbo();
            chatsFrodo = ChatsFrodo();
            chatsSam = ChatsSam();
            chatsMerryPippin = ChatsMerryPippin();
            
        }

        private List<string> ChatsBilbo()
        {
            List<string> chats = new List<string>
            {
                "¡Escóndete, creo que vienen esos Sacovilla-Bolsón!",
                "Es muy peligroso, " + Main.LocalPlayer.name + ", cruzar tu puerta. Pones tu pie en el camino y si no cuidas tus pasos, nunca sabes a dónde te pueden llevar."
            };
            chats.AddRange(ChatsCommon());
            return chats;
        }

        private List<string> ChatsFrodo()
        {
            List<string> chats = new List<string>
            {
                "¿Has visto a mi querido Sam? Hace tiempo que no le veo...",
                "Echo de menos a mi tío Bilbo. Desde que partió hacia Rivendel mi vida ha cambiado mucho."
            };
            chats.AddRange(ChatsCommon());
            return chats;
        }

        private List<string> ChatsSam()
        {
            List<string> chats = new List<string>
            {
                "¿Señor Frodo?"
            };

            if (Main.LocalPlayer.Male)
            {
                chats.Add("Gracias por tener un corazón bondadoso y acogerme aquí, señor " + Main.LocalPlayer.name + ".");
                chats.Add("Luchemos para que el bien reine en este mundo, señor " + Main.LocalPlayer.name + ". Se puede luchar por eso.");
            }
            else
            {
                chats.Add("Gracias por tener un corazón bondadoso y acogerme aquí,  " + Main.LocalPlayer.name + ".");
                chats.Add("Luchemos para que el bien reine en este mundo, señora " + Main.LocalPlayer.name + ". Se puede luchar por eso.");
            }
            chats.AddRange(ChatsCommon());
            return chats;
        }

        private List<string> ChatsMerryPippin()
        {
            List<string> chats = new List<string>
            {
                "Un día tengo que invitarle al Pony Pisador. Buenas pintas sirven allí. Son caras pero merece la pena.",
                "¿Has probado la hierba del viejo Toby? No existe ninguna mejor"
            };
            chats.AddRange(ChatsCommon());
            return chats;
        }

        private List<string> ChatsCommon()
        {
            List<string> chats = new List<string>
            {
                "¡Hola! ¿Sabe cómo llegar a la Comarca? Creo que me he perdido...",
                "¡Menuda casa! Sólo unos pocos pueden permitirse algo así en la Comarca.",
                "¿Eres " + Main.LocalPlayer.name + "? Me han hablado de ti en la taberna de Bree."
            };

            if (NPC.downedBoss1)
                chats.Add("Hizo usted un buen trabajo con ese ojo enorme. Yo también he tenido alguna experiencia con ojos gigantes...");
            if (NPC.downedBoss2)
                chats.Add("No sé cómo es usted capaz de acabar con todas esas abominaciones a las que llaman jefes. ¡Qué haríamos sin usted!");
            if (NPC.downedBoss3)
                chats.Add("¡Y además habéis acabado con el abominable esqueleto! He conocido muy pocos héroes de su nivel.");
            return chats;
        }

    }
}
