using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInput
{
    class Information
    {
        protected string input;
        protected Information next;
        public bool changed;

        public Information()
        {
            next = null;
        }
        public Information(Information next)
        {
            this.next = next;
        }

        public void Add(Information n)
        {
            if (next != null)
            {
                next.Add(n);
            }
            else next = n;
        }

        public virtual string Handle(int id)
        {
            next.Handle(id);
            return input;
        }

        public bool CheckSpecials(string str)
        {
            bool f = true;
            foreach (char c in str)
            {
                if (Char.IsLetterOrDigit(c) || c == '-' || c == '_') continue;
                else return false;
            }
            return f;
        }
        public bool CheckDigits(string str)
        {
            bool f = true;
            foreach (char c in str)
            {
                if (Char.IsDigit(c)) continue;
                else return false;
            }
            return f;
        }

    }

    class HandleLogin: Information
    {
        public override string Handle(int id)
        {
            if (id == 1)
            {
                changed = false;
                do
                {
                    Console.Write("Input login: ");
                    input = Console.ReadLine();
                    if (CheckSpecials(input)) changed = true;
                } while (!changed);
            }
            else input = next.Handle(id);
            return input;

        }
    }

    class HandlePassword: Information
    {
        public override string Handle(int id)
        {
            if (id == 2)
            {
                changed = false;
                do
                {
                    Console.Write("Input password: ");
                    input = Console.ReadLine();
                    if (CheckSpecials(input)) changed = true;
                } while (!changed);
            }
            else input = next.Handle(id);
            return input;

        }
    }

    class HandleEmail: Information
    {
        public override string Handle(int id)
        {
            if (id == 3)
            {
                changed = false;
                do
                {
                    Console.Write("Input email: ");
                    input = Console.ReadLine();
                    if (CheckSpecials(input)) changed = true;
                } while (!changed);
            }
            else input = next.Handle(id);
            return input;

        }
    }

    class HandleNumber : Information
    {
        public override string Handle(int id)
        {
            if (id == 4)
            {
                changed = false;
                do
                {
                    Console.Write("Input number: ");
                    input = Console.ReadLine();
                    if (CheckDigits(input)) changed = true;
                } while (!changed);
            }
            else input = next.Handle(id);
            return input;

        }
    }

    class HandleName : Information
    {
        public override string Handle(int id)
        {
            if (id == 5)
            {
                changed = false;
                do
                {
                    Console.Write("Input name: ");
                    input = Console.ReadLine();
                    if (CheckSpecials(input)) changed = true;
                } while (!changed);
            }
            else input = next.Handle(id);
            return input;

        }
    }

    class HandleBirth : Information
    {
        private bool CheckBirth(string i)
        {
            int counter = 0;
            foreach (char c in i)
            {
                if (c == '.') counter++;
            }
            if (counter == 2 && i.Length == 10) return true;
            else return false;
        }

        public override string Handle(int id)

        {
            if (id == 6)
            {
                changed = false;
                do
                {
                    Console.Write("Input birth: ");
                    input = Console.ReadLine();
                    if (CheckBirth(input)) changed = true;
                } while (!changed);
            }
            else input = next.Handle(id);
            return input;

        }
    }
    
    class Account
    {
        string login, password, email, number, name, birth;

        public Account()
        {
            login = "login";
            password = "password";
            email = "email";
            number = "number";
            name = "name";
            birth = "birth";
        }
        public void Show()
        {
            Console.WriteLine("Login: {0}\nPassword: {1}\nEmail: {2}\nNumber: {3}\nName: {4}\nDate of birth: {5}", login, password, email, number, name, birth);
        }
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account();
            HandleLogin login = new HandleLogin();
            HandlePassword password = new HandlePassword();
            HandleEmail email = new HandleEmail();
            HandleNumber number = new HandleNumber();
            HandleName name = new HandleName();
            HandleBirth birth = new HandleBirth();
            login.Add(password);
            login.Add(email);
            login.Add(number);
            login.Add(name);
            login.Add(birth);

            InputData(acc, login);

            acc.Show();

            Console.ReadLine();
        }

        static void InputData(Account acc, HandleLogin login)
        {
            bool f;
            string str;

            str = login.Handle(1);
            acc.Login = str;
            str = "";
            str = login.Handle(2);
            acc.Password = str;
            str = "";

            str = login.Handle(3);
            acc.Email = str;
            str = "";

            str = login.Handle(4);
            acc.Number= str;
            str = "";

            str = login.Handle(5);
            acc.Name= str;
            str = "";

            str = login.Handle(6);
            acc.Birth = str;
        }
    }
}
