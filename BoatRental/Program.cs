using System;
using System.Collections.Generic;
using System.Linq;

namespace BoatRental
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Boat> list = new List<Boat>() {
                new Boat{ Size = "Tiny" , Seat = 5 , Cost = 5 },
                new Boat{ Size = "Medium" , Seat = 10 , Cost = 8 },
                new Boat{ Size = "Large" , Seat = 15 , Cost = 12 }
            };

            Console.Write("How many seats : ");
            string value = Console.ReadLine();

            int seat = Convert.ToInt32(value);

            var model = CheckSeat(seat, list);
        }

        private static Boat CheckSeat(int seat, List<Boat> demoList)
        {
            Boat lowModel = demoList.Aggregate((i1, i2) => i1.Seat < i2.Seat ? i1 : i2);
            if (seat < lowModel.Seat)
            {
                return lowModel;
            }
            else
            {
               
            }
            return null;
        }

    }


}
