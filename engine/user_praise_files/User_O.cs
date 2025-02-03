
namespace Client_Assembly.Praise_Files
{
    public class User_O
    {
        static private Client_Assembly.Praise_Files.Praise1_Output praise1_Output;
        static private Client_Assembly.Praise_Files.Praise2_Output praise2_Output;

        public User_O()
        {
            praise1_Output = new Client_Assembly.Praise_Files.Praise1_Output();
            praise2_Output = new Client_Assembly.Praise_Files.Praise2_Output();
        }

        public Client_Assembly.Praise_Files.Praise1_Output GetPraise0_Outnput()
        {
            return praise1_Output;
        }

        public Client_Assembly.Praise_Files.Praise2_Output GetPraise1_Output()
        {
            return praise2_Output;
        }
    }
}
