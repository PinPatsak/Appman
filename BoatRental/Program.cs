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

        private static List<Boat> CheckSeat(int seat, List<Boat> demoList)
        {
            Boat lowModel = demoList.Aggregate((i1, i2) => i1.Seat < i2.Seat ? i1 : i2);

            List<Boat> list = new List<Boat>();

            if (seat <= lowModel.Seat)
            {
                list.Add(lowModel);
                return list;
            }
            
            while (true)
            {
                Boat temp = demoList.Aggregate((i1, i2) => i1.Seat <= seat && seat < i2.Seat ? i1 : i2);
                seat = seat - temp.Seat;
                list.Add(temp);
                if (seat < lowModel.Seat)
                {
                    if(seat != 0)
                        list.Add(lowModel);

                    break;
                }

            }

            
            return list;
        }



    }


}
