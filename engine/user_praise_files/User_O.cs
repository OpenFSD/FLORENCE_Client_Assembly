
namespace Client_Assembly.Praise_Files
{
    public class User_O
    {
        static private Client_Assembly.Praise_Files.Praise0_Output praise0_Output;
        static private Client_Assembly.Praise_Files.Praise1_Output praise1_Output;

        public User_O()
        {
            praise0_Output = new Client_Assembly.Praise_Files.Praise0_Output();
            praise1_Output = new Client_Assembly.Praise_Files.Praise1_Output();
        }

        public Client_Assembly.Praise_Files.Praise0_Output GetPraise0_Outnput()
        {
            return praise0_Output;
        }

        public Client_Assembly.Praise_Files.Praise1_Output GetPraise1_Output()
        {
            return praise1_Output;
        }
    }
}
