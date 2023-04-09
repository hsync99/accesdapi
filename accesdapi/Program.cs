using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesdapi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBAPI dBAPI = new DBAPI();
            Phone phone = new Phone();
            phone.Name = "Test";
            phone.Location = "Test";
            phone.Calls1 = 10;
            phone.Calls2= 20;   
            phone.Number= "+77056662035";
           List<Phone> phones= new List<Phone>();
            //phones = dBAPI.ReadDataFromDb();
           Console.WriteLine(dBAPI.DeleteDataFromDbById("Абоненты","4"));
            //foreach(Phone phone in phones) {
            //    Console.WriteLine(phone.Name + " " + phone.Number);
            //}
            Console.ReadKey();

        }
    }
}
