using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpensesTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Expense> expensesList = new List<Expense>(); 

            string option;
            do
            {
                ShowMenu(); 
                option = Console.ReadLine(); 

                switch (option)
                {
                    case "1":
                        AddExpense(expensesList);
                        break;
                    case "2":
                        ViewExpenses(expensesList);
                        break;
                    case "3":
                        CalculateTotalExpenses(expensesList);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }

            } while (option != "4"); 
        }

        static void ShowMenu()
        {
            Console.WriteLine("----- Personal Expense Tracker -----");
            Console.WriteLine("1. Add new expense");
            Console.WriteLine("2. View all expenses");
            Console.WriteLine("3. Calculate total expenses");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
        }

        static void AddExpense(List<Expense> expensesList)
        {
            Console.WriteLine("\n--- Add New Expense ---");

            Console.Write("Enter expense title: ");
            string title = Console.ReadLine();

            Console.Write("Enter expense date (dd/mm/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();

            Console.Write("Enter expense description: ");
            string description = Console.ReadLine();

            Console.Write("Enter expense amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Expense newExpense = new Expense
            {
                Title = title,
                Date = date,
                Category = category,
                Description = description,
                Amount = amount
            };

            expensesList.Add(newExpense);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Expense added successfully.\n");
            Console.ResetColor(); 
        }

        static void ViewExpenses(List<Expense> expensesList)
        {
            Console.WriteLine("\n--- List of Expenses ---");

            if (expensesList.Count == 0)
            {
                Console.WriteLine("No expenses recorded.\n");
                return;
            }

            foreach (var expense in expensesList)
            {
                Console.WriteLine($"Title: {expense.Title}");
                Console.WriteLine($"Date: {expense.Date.ToShortDateString()}");
                Console.WriteLine($"Category: {expense.Category}");
                Console.WriteLine($"Description: {expense.Description}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Amount: {expense.Amount:C}");
                Console.ResetColor(); 

                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine();
        
    }

        static void CalculateTotalExpenses(List<Expense> expensesList)
        {
            if (expensesList.Count == 0)
            {
                Console.WriteLine("No expenses recorded yet.\n");
                return;
            }

            decimal total = expensesList.Sum(e => e.Amount);

            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nTotal expenses: {total:C}\n");
            Console.ResetColor(); 
        }
    }
}
