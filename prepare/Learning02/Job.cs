using System;

class Job
{
    public string JobTitle { get; set; }
    public string Company { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }

    public Job(string jobTitle, string company, string startDate, string endDate)
    {
        JobTitle = jobTitle;
        Company = company;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void Display()
    {
        Console.WriteLine($"{JobTitle} ({Company}) {StartDate}-{EndDate}");
    }
}
