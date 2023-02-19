

namespace KEP
{
    public class Employee//public class to get employees info
    {
        public string Name;
        public string Date;
        //setters and getters
        public void setName(string Name) { this.Name = Name; }
        public void setDate(string Date) { this.Date = Date; }
        public string getName() { return Name; }
        public string getDate() { return Date; }
            
        public Employee(string name, string date)//constructor of object
        {
            setName(name);
            setDate(date);

        }
    }
}
