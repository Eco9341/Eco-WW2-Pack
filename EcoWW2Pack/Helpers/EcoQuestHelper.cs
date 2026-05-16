using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Services;
using WTTServerCommonLib.Helpers;

namespace EcoWW2Pack.Helpers
{
    [Injectable]
    public class EcoQuestHelper(DatabaseService  databaseService, ISptLogger<EcoQuestHelper> logger, QuestHelper questHelper)
    {

        // Define weapon IDs
        // ReSharper disable InconsistentNaming
        // ReSharper disable IdentifierTypo
        //snipers
        private const string Carcano_1891_M91 = "69e61fe28a819d09900d74e5";
        private const string Carcano_1891_M38 = "69edf6bcd573e25abc40203b";
        private const string Carcano_1891_MOSCHETTO = "69eea8b5a9682e6879a537d8";
        //shotguns
        
        //smg
        private const string THOMPSON_M1928 = "69eea8b5a9682e6879a537d8";  
        //pistols
        
        //rifles 
        private const string CEI_RIGOTTI = "6a06febcf86e3e091872c104";
        //dmr
        
        // Weapon Mods
        
        public void ModifyQuests()
        {
            var quests = databaseService.GetTemplates().Quests;

            // ReSharper disable CommentTypo
            // ====================== PRAPOR QUESTS ======================
            //
            // // Punisher Part 4 (59ca264786f77445a80ed044)
            // questHelper.AddWeaponsToKillCondition(quests, "59ca264786f77445a80ed044", [
            //     BP12, BP12_GEN2, B1301, B1301_FDE, B1301_GREEN
            // ]);

            // // Mall Cop (64e7b99017ab941a6f7bf9d7)
            // questHelper.AddWeaponsToKillCondition(quests, "64e7b99017ab941a6f7bf9d7", [
            //     MK22_HUSHPUPPY, AMT_HARDBALLER
            // ]);

            // Tickets, Please (64e7b9a4aac4cd0a726562cb)
             questHelper.AddWeaponsToKillCondition(quests, "64e7b9a4aac4cd0a726562cb", [
                 THOMPSON_M1928
             ]);

            // District Patrol (64e7b9bffd30422ed03dad38)
            questHelper.AddWeaponsToKillCondition(quests, "64e7b9bffd30422ed03dad38", [
                CEI_RIGOTTI
            ]);

            // ====================== SKIER QUESTS ======================

            // // Stirrup (596b455186f77457cb50eccb)
            // questHelper.AddWeaponsToKillCondition(quests, "596b455186f77457cb50eccb", [
            //     MK22_HUSHPUPPY, AMT_HARDBALLER
            // ]);

            // // Silent Caliber (5c0bc91486f7746ab41857a2)
            // questHelper.AddWeaponsToKillCondition(quests, "5c0bc91486f7746ab41857a2", [
            //     BP12, BP12_GEN2, B1301, B1301_FDE, B1301_GREEN
            // ]);
            //
            // // Setup (5c1234c286f77406fa13baeb)
            // questHelper.AddWeaponsToKillCondition(quests, "5c1234c286f77406fa13baeb", [
            //     BP12, BP12_GEN2, B1301, B1301_FDE, B1301_GREEN
            // ]);

            // Connections Up North (6764174c86addd02bc033d68)
            questHelper.AddWeaponsToKillCondition(quests, "6764174c86addd02bc033d68", [
                Carcano_1891_M91, Carcano_1891_M38, Carcano_1891_MOSCHETTO
            ]);

            // ====================== PEACEKEEPER QUESTS ======================

            // // Spa Tour Part 1 (5a03153686f77442d90e2171)
            // questHelper.AddWeaponsToKillCondition(quests, "5a03153686f77442d90e2171", [
            //     BP12, BP12_GEN2, B1301, B1301_FDE, B1301_GREEN
            // ]);
            //
            // // Worst Job (63a9b229813bba58a50c9ee5)
            // questHelper.AddWeaponsToKillCondition(quests, "63a9b229813bba58a50c9ee5", [
            //     LR300, LR300_FDE, TT_TR1, BRN180, BRN180_FDE
            // ]);

            // ====================== JAEGER QUESTS ======================

            var tarkovShooterWeapons = new[]
            {
                Carcano_1891_M91, Carcano_1891_M38, Carcano_1891_MOSCHETTO
            };

            // Tarkov Shooter Part 1-8 (WEAPONS)
            questHelper.AddWeaponsToKillCondition(quests, "5bc4776586f774512d07cf05", tarkovShooterWeapons); // Part 1
            questHelper.AddWeaponsToKillCondition(quests, "5bc479e586f7747f376c7da3", tarkovShooterWeapons); // Part 2
            questHelper.AddWeaponsToKillCondition(quests, "5bc47dbf86f7741ee74e93b9", tarkovShooterWeapons); // Part 3
            questHelper.AddWeaponsToKillCondition(quests, "5bc480a686f7741af0342e29", tarkovShooterWeapons); // Part 4
            questHelper.AddWeaponsToKillCondition(quests, "5bc4826c86f774106d22d88b", tarkovShooterWeapons); // Part 5
            questHelper.AddWeaponsToKillCondition(quests, "5bc4836986f7740c0152911c", tarkovShooterWeapons); // Part 6
            questHelper.AddWeaponsToKillCondition(quests, "5bc4856986f77454c317bea7", tarkovShooterWeapons); // Part 7
            questHelper.AddWeaponsToKillCondition(quests, "5bc4893c86f774626f5ebf3e", tarkovShooterWeapons); // Part 8

            // Tarkov Shooter Part 1-8 (MODS)
            
            // Part 1
            
            // Part 7


            
            // // Claustrophobia (669fa3979b0ce3feae01a130)
            // questHelper.AddWeaponsToKillCondition(quests, "669fa3979b0ce3feae01a130", [
            //     BP12, BP12_GEN2, B1301, B1301_FDE, B1301_GREEN
            // ]);

            // ====================== MECHANIC QUESTS ======================

            // Psycho Sniper (5c0be13186f7746f016734aa)
            questHelper.AddWeaponsToKillCondition(quests, "5c0be13186f7746f016734aa", [
                Carcano_1891_M91, Carcano_1891_M38, Carcano_1891_MOSCHETTO
            ]);

            // Shooter Born in Heaven (5c0bde0986f77479cf22c2f8)
            questHelper.AddWeaponsToKillCondition(quests, "5c0bde0986f77479cf22c2f8", [
                Carcano_1891_M91, Carcano_1891_M38, Carcano_1891_MOSCHETTO
            ]);
        }
    }
}
