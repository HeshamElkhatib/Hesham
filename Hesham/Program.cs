using System;
using Starcounter;
using System.Collections;
using Hesham.Models;

namespace Hesham
{
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            DataSeeder seeder = new DataSeeder();
            seeder.Seed();

            RequestsHandler requestsHandler = new RequestsHandler();
            requestsHandler.AddHandlers();
        }
    }
}