using System;

namespace Bank.Entity
{
    public class User
    {
        public User(string id,string block, string first_name, string last_name,string pin, string main_currency, string user_try)
        {
            this.id = id;
            this.block = block;
            this.first_name = first_name;
            this.last_name = last_name;
            this.pin = pin;
            this.main_currency = main_currency;
            this.user_try = user_try;
        }
        
        
        public string id;
        public string block;
        public string first_name;
        public string last_name;
        public string pin;
        public string main_currency;
        public string user_try;
    }
}