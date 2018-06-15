using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckInput
{
    class Information
    {
        // '+', '/', '*', ')', '(', '\"', '\'', '\\', '&', '^', '$', '#', '!', '?', '>', '<', ':', ';', ']', '[', ',', '~', '`', '/', '|'
        protected string input;
        protected Information next;
        public changed 

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

        public virtual void Handle(string i, int id)
        {
            next.Handle(i, id);
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
        public override void Handle(string i, int id)
        {
            if (id == 1)
            {
                if (CheckSpecials(i)) Console.WriteLine("Login successfully changed");
                else
                {
                    Console.WriteLine("Wrong login format.");
                }
            }
            else
            {
                next.Handle(i, id);
            }
        }
    }

    class HandlePassword: Information
    {
        public override void Handle(string i, int id)
        {
            if (id == 2)
            {
                if (CheckSpecials(i)) Console.WriteLine("Password successfully changed");
                else
                {
                    Console.WriteLine("Wrong password format.");
                }
            }
            else
            {
                next.Handle(i, id);
            }
        }
    }

    class HandleEmail: Information
    {
        public override void Handle(string i, int id)
        {
            if (id == 3)
            {
                if (CheckSpecials(i)) Console.WriteLine("Email successfully changed");
                else
                {
                    Console.WriteLine("Wrong email format.");
                }
            }
            else
            {
                next.Handle(i, id);
            }
        }
    }

    class HandleNumber : Information
    {
        public override void Handle(string i, int id)
        {
            if (id == 4)
            {
                if (CheckDigits(i)) Console.WriteLine("Number successfully changed") ;
                else
                {
                    Console.WriteLine("Wrong number format.");
                }
            }
            else
            {
                next.Handle(i, id);
            }
        }
    }

    class HandleName : Information
    {
        public override void Handle(string i, int id)
        {
            if (id == 5)
            {
                if (CheckSpecials(i)) Console.WriteLine("Name successfully changed");
                else
                {
                    Console.WriteLine("Wrong name format.");
                    
                }
            }
            else
            {
                next.Handle(i, id);
                
            }
        }
    }

    class HandleBirth : Information
    {
        public override void Handle(string i, int id)
        {
            if (id == 6)
            {
                if (CheckSpecials(i)) Console.WriteLine("Date of birth successfully changed");
                else
                {
                    Console.WriteLine("Wrong birth format.");
                }
            }
            else
            {
                next.Handle(i, id);
            }
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
            do
            {
                Console.Write("Enter login: ");
                str = Console.ReadLine();
                login.Handle(str, 1);
            } while ();
            acc.Login = str;

            do
            {
                Console.Write("Enter password: ");
                str = Console.ReadLine();
                login.Handle(str, 2);
            } while (!f);
            acc.Password = str;

            do
            {
                Console.Write("Enter email: ");
                str = Console.ReadLine();
                login.Handle(str, 3);
            } while (!f);
            acc.Email = str;

            do
            {
                Console.Write("Enter number: ");
                str = Console.ReadLine();
                login.Handle(str, 4);
            } while (!f);
            acc.Number = str;

            do
            {
                Console.Write("Enter name: ");
                str = Console.ReadLine();
                login.Handle(str, 5);
            } while (!f);
            acc.Name = str;

            do
            {
                Console.Write("Enter date of birth: ");
                str = Console.ReadLine();
                login.Handle(str, 6);
            } while (!f);
            acc.Birth = str;

        }
    }
}
