using System.Data;
using System.Net.WebSockets;
using Microsoft.Data.SqlClient;
using Library.Models;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    static class Information
    {
        [STAThread]
        static void Main(string[] args)
        {
            //var db = new Database();
            var book = new BOOK();
            var member = new Member();
            var history = new History();
            var memberRepository = new MemberRepository();
            var bookRepository = new BookRepository();
            var historyRepository = new HistoryRepository();
            bookRepository = new BookRepository();
            memberRepository = new MemberRepository();
            historyRepository = new HistoryRepository();
            Console.WriteLine("\t**Welcome to Library**\t\n");
            string _anwser;
            string _select;
            string _choose;
            string _bookID;
            Console.WriteLine("Are you selecting or want to make a edit?!\n A : Edit \n B : Selcet");
            _select = Console.ReadLine();

            switch (_select.ToUpper())
            {
                case "A":
                {
                    Console.WriteLine("Which table would you like to edit?:");
                    Console.WriteLine(" a-Book \n b-Member \n c-History");
                    _anwser = Console.ReadLine();
                    switch (_anwser.ToUpper())
                    {
                            
                        case "A":
                        {
                            Console.WriteLine(
                                "Would you like to add,update or delete a record ?\n 1 : insert \n 2 : update \n 3 : delete ");
                            int ch = Convert.ToInt16(Console.ReadLine());
                            

                            if (ch == 1)

                            {

                                Console.Write("Enter ISBN : ");
                                book.ISBN = (int)Convert.ToInt64(Console.ReadLine());

                                Console.Write("Enter Title : ");
                                book.Title = Console.ReadLine();

                                Console.WriteLine("Eneter Author : ");
                                book.Author = Console.ReadLine();

                                Console.Write("Enter Publish year : ");
                                book.publishyear = (int)Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Eneter Category : ");
                                book.category = Console.ReadLine();
                                bookRepository.Insert(book);
                            }

                            else
                            {
                                if
                                    (ch == 2)
                                {
                                    Console.WriteLine("Enter your Book ID :");
                                    book.BookID = (int)Convert.ToInt64(Console.ReadLine());

                                    Console.Write("Enter ISBN : ");
                                    book.ISBN = (int)Convert.ToInt64(Console.ReadLine());

                                    Console.Write("Enter Title : ");
                                    book.Title = Console.ReadLine();

                                    Console.WriteLine("Eneter Author : ");
                                    book.Author = Console.ReadLine();

                                    Console.Write("Enter Publish year : ");
                                    book.publishyear = (int)Convert.ToInt64(Console.ReadLine());

                                    Console.WriteLine("Eneter Category : ");
                                    book.category = Console.ReadLine();
                                    bookRepository.Update(book);
                                }
                                else
                                {
                                    if (ch == 3)
                                    {
                                        Console.Write("Enter Book ID : ");
                                        book.BookID = Convert.ToInt32(Console.ReadLine());
                                        bookRepository.Delete(book);
                                    }
                                }
                            }
                        }

                            break;
                        case "B":
                        {
                            Console.WriteLine(
                                "Would you like to add,update or delete a record ?\n 1 : insert \n 2 : update \n 3 : delete ");
                            int bh = Convert.ToInt16(Console.ReadLine());
                            if (bh == 1)
                            {
                                Console.Write("Enter FirstName : ");
                                member.Firstname = Console.ReadLine();

                                Console.Write("Enter LastName : ");
                                member.Lastname = Console.ReadLine();

                                Console.WriteLine("Eneter Adress : ");
                                member.AddressM = Console.ReadLine();

                                Console.Write("Enter Phone Number : ");
                                member.phonenumber = (int)Convert.ToInt64(Console.ReadLine());

                                Console.WriteLine("Eneter Limit : ");
                                member.LimitM = Convert.ToInt32(Console.ReadLine());
                                memberRepository.InsertMember(member);
                            }
                            else
                            {
                                if (bh == 2)
                                {
                                    Console.WriteLine("Enter your member ID :");
                                    member.memberID = (int)Convert.ToInt64(Console.ReadLine());

                                    Console.Write("Enter FirstName : ");
                                    member.Firstname = Console.ReadLine();

                                    Console.Write("Enter LastName : ");
                                    member.Lastname = Console.ReadLine();

                                    Console.WriteLine("Eneter Adress : ");
                                    member.AddressM = Console.ReadLine();

                                    Console.Write("Enter Phone Number : ");
                                    member.phonenumber = (int)Convert.ToInt64(Console.ReadLine());

                                    Console.WriteLine("Enter Limit : ");
                                    member.LimitM = Convert.ToInt32(Console.ReadLine());
                                    memberRepository.Update(member);
                                }
                                else
                                {
                                    if (bh == 3)
                                    {
                                        Console.Write("Enter Member ID : ");
                                        member.memberID = Convert.ToInt32(Console.ReadLine());
                                        memberRepository.Delete(member);
                                    }
                                }
                            }
                        }
                            break;
                        case "C":
                        {
                            Console.WriteLine(
                                "Would you like to add,update or delete a record ?\n 1 : insert \n 2 : update \n 3 : delete ");

                            int hh = Convert.ToInt16(Console.ReadLine());
                            if (hh == 1)
                            {


                                Console.WriteLine("Enter Member ID :");
                                history.memberID = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter Book ID :");
                                history.bookID = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter loan Date history : ");
                                history.loandate = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Eneter return date history : ");
                                history.returndate = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Eneter due date history : ");
                                history.duedate = Convert.ToInt32(Console.ReadLine());
                                historyRepository.Insert(history);

                            }
                            else
                            {
                                if (hh == 2)
                                {
                                    Console.WriteLine("Enter HISTORY ID :");
                                    history.Id = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Member ID :");
                                    history.memberID = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter Book ID :");
                                    history.bookID = Convert.ToInt32(Console.ReadLine());

                                    Console.Write("Enter lean Date history : ");
                                    history.loandate = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter return Date history : ");
                                    history.returndate = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter DUE DATE history : ");
                                    history.duedate = Convert.ToInt32(Console.ReadLine());
                                    historyRepository.Update(history);
                                }
                                else
                                {
                                    if (hh == 3)
                                    {
                                        Console.Write("Enter History ID : ");
                                        history.Id = Convert.ToInt32(Console.ReadLine());
                                        historyRepository.Delete(history);
                                    }
                                }
                            }


                        }
                            break;

                    }
                }
                    break;

                case "B":
                {

                    Console.WriteLine
                        ("Would you like to select a record ?\n A : select Book \n B : select Member \n C : select History ");
                    _choose = (Console.ReadLine());



                    switch (_choose.ToUpper())
                    {
                        case "A":
                        {
                            Console.WriteLine
                                ("Whould you like to Select a Book : \n 1 : select By ID \n 2 : select All \n 3: select By words");

                            int pm = Convert.ToInt16(Console.ReadLine());
                            if (pm == 1)
                            {

                                Console.WriteLine("Enter BookId : \n");
                                _bookID = Console.ReadLine();
                                var bid = bookRepository.GetById(1);
                                bid.Printbook();
                            }
                            else
                            {
                                if (pm == 2)
                                {
                                    var allBooks = bookRepository.SelectAll();

                                    foreach (var b in allBooks)
                                    {
                                        b.Printbook();
                                    }
                                }
                                else
                                {
                                    if (pm == 3)
                                    {
                                        Console.WriteLine("inter the name");
                                        var myname = Console.ReadLine();
                                        var findThename = bookRepository.FindByName(myname);
                                        foreach (var b in findThename)
                                        {
                                            b.Printbook();
                                        }
                                    }
                                }
                            }
                        }
                            break;



                        case "B":
                        {
                            Console.WriteLine
                                ("Whould you like to Select a Member : \n 1 : select By ID \n 2 : select All \n 3 : select By words");

                            int mg = Convert.ToInt16(Console.ReadLine());
                            if (mg == 1)
                            {
                                var member1 = memberRepository.GetById(1);
                            }
                            else
                            {
                                if (mg == 2)
                                {
                                    var allMembers = memberRepository.SelectAll();

                                    foreach (var m in allMembers)
                                    {
                                        m.printMember();
                                    }
                                }
                                else
                                {
                                    if (mg == 3)
                                    {
                                        Console.WriteLine("inter the name");
                                        var myname = Console.ReadLine();
                                        var findThename = memberRepository.FindByName(myname);
                                        foreach (var b in findThename)
                                        {
                                            b.printMember();
                                        }
                                    }
                                }
                            }
                        }
                            break;
                        case "C":
                        {
                            Console.WriteLine
                                ("Whould you like to Select a History : \n 1 : select By ID \n 2 : select All \n 3: select By words");
                            int hs = Convert.ToInt16(Console.ReadLine());
                            if (hs == 1)
                            {
                                var history1 = historyRepository.GetById(1);
                            }
                            else
                            {
                                if (hs == 2)
                                {
                                    var allhistory = historyRepository.SelectAll();

                                    foreach (var h in allhistory)
                                    {
                                        h.printhistory();
                                    }
                                }

                               
                            }
                        } break;
                    }
                } break;
            }
        }
    }
}











                    
                    
            

            


        
    



    
      
    
    
    
    
    
    
    
    
    
    
    
