using ClassLib.Interfaces;

namespace ClassLib.Classes
{
    public abstract class User
    {
        private int id;
        private string accType;
        private string name;
        private string email;
        private int phoneNumber;
        public User(int id, string accType, string name, string email, int phoneNumber)
        {
            this.id = id;
            this.accType = accType;
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;

        }

        public int GetId()
        {
            return id;
        }

        public string GetName() { return name; }
        public string GetEmail() { return email; }
        public string GetPhoneNumber() { return $"0" + phoneNumber.ToString(); }

        public string GetAccountType() { return accType; }

    }
}
