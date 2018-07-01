using System;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using System.Threading;

namespace ZeroAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            Application application = Application.Attach(@"Pi");
            Window window = application.GetWindow(SearchCriteria.ByAutomationId("frmMain"), InitializeOption.WithCache);

            Panel alertPanel = window.Get<Panel>("ctlScanner");

            Table alertTable = alertPanel.Get<Table>(SearchCriteria.Indexed(0));

            foreach (var row in alertTable.Rows)
            {
                Console.WriteLine(row.Name + ": ");
                foreach(var cell in row.Cells)
                {
                    Console.Write(cell.NameTrimmed() + ": " + cell.Value + ", ");

                    if (cell.NameTrimmed() == "Trade")
                    {
                        cell.Click();
                        window.WaitWhileBusy();
                        window.WaitTill(() => WhenOrderWindowAppears(window));

                        // Wait till order window appears
                        Console.WriteLine("Order window pened");

                    }
                }
            }

            Console.ReadLine();
        }

        private static bool WhenOrderWindowAppears(Window window)
        {
            Window orderWindow = window.Get<Window>(SearchCriteria.Indexed(0));
            if (orderWindow != null)
                return true;
            else
                return false;
        }
    }
}
