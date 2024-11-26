// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main()
    {
        Random attackValue = new Random();

        int damage = 0;
        String attacker = "";
        String opponent = "";
        int opponentHealth = 0;
        int attackerHealth = 0;

        String startMessage = "Gimli had a few ales too many, and now he and an unlucky Urk-Hai are having a scuffle";
        string swingPunch()
        {
            return attacker + " swings a punch...";
        } 
        string doesDamage()
        {
            return "He does " + damage + " damage to " + opponent + "!";
        }
        String orc = "Uruk-Hai";
        String dwarf = "Gimli";
        string announceHealth()
        {
            return opponent + "'s health is down to " + opponentHealth;
        }
        String newLine = "\n";
        string announceWinner()
        {
            return attacker + " has won, with " + attackerHealth + " health left! He smashed " + opponent + " to bits.";
        }
        String end = "Thank you for spectating! See you next time.";
        

        int orcHealth = 200;
        int dwarfHealth = 200;

        void d20Roll()
        {
            damage = attackValue.Next(1, 21);
        }

        void turnChange()
        {   
            String changeAttackerTo = opponent;
            String ChangeOpponentTo = attacker;
            int changeOpponentHealthTo = attackerHealth;
            int changeAttackerHealthTo = opponentHealth;
            
            attacker = changeAttackerTo;
            opponent = ChangeOpponentTo;
            attackerHealth = changeAttackerHealthTo;
            opponentHealth = changeOpponentHealthTo;
        }

        void MessageSpectator(string message)
        {
            Console.WriteLine(message);
        }

        void Attack()
        {
            MessageSpectator(newLine);
            MessageSpectator(swingPunch());
            d20Roll();
            MessageSpectator(doesDamage());
            opponentHealth = opponentHealth - damage;
            MessageSpectator(announceHealth());

            switch(attacker)
            {
                case "Uruk-Hai":
                    dwarfHealth = opponentHealth;
                    break;
                case "Gimli":
                    orcHealth = opponentHealth;
                    break;
            }            
        }

        void ChooseStart(string startingAttacker)
        {
            if(startingAttacker == "Uruk-Hai")
            {
                attacker = startingAttacker;
                attackerHealth = orcHealth;
                opponent = dwarf;
                opponentHealth = dwarfHealth;
            }
            else if(startingAttacker == "Gimli")
            {
                attacker = startingAttacker;
                attackerHealth = dwarfHealth;
                opponent = orc;
                opponentHealth = orcHealth;
            }
        }

        void AnnounceOutcome()
        {
            MessageSpectator(newLine);
            MessageSpectator(announceWinner());
            MessageSpectator(end);
        }

        void Game()
        {
            MessageSpectator(startMessage);
            ChooseStart(orc);
            Attack();
            while(orcHealth > 0 && dwarfHealth > 0)
            {
                turnChange();
                Attack();
            }
            AnnounceOutcome();
        }

        Game();
    }
}
