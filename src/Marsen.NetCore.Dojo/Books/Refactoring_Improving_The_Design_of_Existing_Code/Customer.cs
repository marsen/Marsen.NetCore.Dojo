using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Marsen.NetCore.Dojo.Books.Refactoring_Improving_The_Design_of_Existing_Code;

public class Customer
{
    private readonly string _name;
    private readonly List<Rental> _rentals = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="Customer" /> class.
    /// </summary>
    public Customer(string name)
    {
        _name = name;
    }

    public void AddRental(Rental arg)
    {
        _rentals.Add(arg);
    }

    private string GetName()
    {
        return _name;
    }

    public string Statement()
    {
        IEnumerator rentals = _rentals.GetEnumerator();
        var stringBuilder = new StringBuilder($"Rental Record for {GetName()}\n");
        while (rentals.MoveNext())
        {
            var each = (Rental)rentals.Current;

            //show figures for this rental
            stringBuilder.Append($"\t{each.GetMovie().GetTitle()}\t{each.GetCharge()}\n");
        }

        //add footer lines
        stringBuilder.Append($"Amount owed is {GetTotalAmount()}\n");
        stringBuilder.Append($"You earned {GetFrequentRenterPoints()} frequent renter points");
        return stringBuilder.ToString();
    }

    private double GetTotalAmount()
    {
        double result = 0;
        IEnumerator rentals = _rentals.GetEnumerator();
        while (rentals.MoveNext())
        {
            var each = (Rental)rentals.Current;
            result += each.GetCharge();
        }

        return result;
    }

    private int GetFrequentRenterPoints()
    {
        var result = 0;

        IEnumerator rentals = _rentals.GetEnumerator();
        while (rentals.MoveNext())
        {
            var each = (Rental)rentals.Current;
            result += each.GetFrequentRenterPoints();
        }

        return result;
    }
}