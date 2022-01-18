using System;
using System.Collections.Generic;
using System.Linq;

namespace VS_CODE_DAY1
{
    class Program
    {
       static List<Member> members = new List<Member>
        {
            new Member
            {
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 1, 22),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 20),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 6),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 26),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 2, 5),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        };

        static void Main(string[] args)
        {
            // 1.return a list of members who is male
            // var maleMembers = GetMaleMembers();
            // Printdata (maleMembers);
            // 2.Find oldest member
            // var oldest = GetOldestMember();
            // Printdata(new List<Member> {oldest});
            // 3.Member full name
            // var fullnames = GetFullNames();
            // foreach(var fullname in fullnames)
            // {
            //    Console.WriteLine(fullname);
            // }
            // 4.Split member by year
            // var results = SplitMembersByBirthYear(2000);
            // Printdata(results.Item1); 
            // Console.WriteLine("-----------------------");
            // Printdata(results.Item2);  
            // Console.WriteLine("-----------------------");
            // Printdata(results.Item3);  
           //5. Get HaNoi base
            var result = GetFirstMemberByBirthPlace("Ha Noi");
            if (result != null)
            {
                Printdata(new List<Member> {result});                
            } else
            {
                Console.WriteLine("No data.");
            }
            
        }
        static void Printdata(List<Member> data)
        {
            var index = 0;
            foreach (var item in data)
            {
                ++index;
                Console.WriteLine($"{index}. {item.LastName} {item.FirstName} - {item.DateOfBirth.ToString("dd/MM/yyyy")}-[{item.Age}]");
            } 
        }
        static List<Member> GetMaleMembers()
    
        {
            // var results = members.Where(x => x.Gender == "Male").ToList();
            var results = from member in members
                        where member.Gender == "Male"
                        select member;
            return results.ToList();
        }
        static Member GetOldestMember()
        {
            var oderedList = from member in members
                        orderby member.TotalDays descending // descending = DESC
                        select member; 
            return oderedList.First();
        }
        static List<string> GetFullNames()
        {
        //    var fullNames = members.Select(m => m.FullName);
        //     return fullNames.ToList();
            var fullNames = from member in members
                            select member.FullName;
            return fullNames.ToList();
        }
        static Tuple<List<Member>, List<Member>,List<Member>> SplitMembersByBirthYear(int year)
        {
            var list1 = (from member in members 
                        where member.DateOfBirth.Year == year
                        select member ).ToList();
            var list2 = (from member in members 
                        where member.DateOfBirth.Year > year
                        select member ).ToList();
            var list3 = (from member in members 
                        where member.DateOfBirth.Year < year
                        select member ).ToList();
            
            return Tuple.Create(list3,list1,list2);
        }
        static Member? GetFirstMemberByBirthPlace(string place)
    
        {
            var results = from member in members
                          where member.BirthPlace.Equals(place, StringComparison.CurrentCultureIgnoreCase)
                          select member;
            return results.FirstOrDefault();
        }
    }
}
