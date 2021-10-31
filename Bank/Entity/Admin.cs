namespace Bank.Entity
{
    public class Admin
    {
        public Admin(string id, string identifiant, string password)
        {
            this.id = id;
            this.identifiant = identifiant;
            this.password = password;
        }
        
        public string id;
        public string identifiant;
        public string password;
    }
}