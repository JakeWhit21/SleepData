// See https://aka.ms/new-console-template for more information
string file = "data.txt";
// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // create data file

    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
        // random number generator
    Random rnd = new Random();
     // create file
    StreamWriter sw = new StreamWriter("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        // Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    if (File.Exists(file))
        {
            // read data from file
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                //grab individual date
                string[] dateValues = line.Split(',');
                //convert string date to parsed date
                DateTime parsedDate = DateTime.Parse(dateValues[0]);

                //split each day
                string[] daysOfSleep = line.Split('|', ',');
                
                //write the week
                Console.WriteLine($"Week of {parsedDate:MMM}, {parsedDate:dd}, {parsedDate:yyyy}");

                //write each day
                Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}", "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa");
                Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}", "--", "--", "--", "--", "--", "--", "--");
                Console.WriteLine("{0,3}{1,3}{2,3}{3,3}{4,3}{5,3}{6,3}", daysOfSleep[1], daysOfSleep[2], daysOfSleep[3], daysOfSleep[4], daysOfSleep[5], daysOfSleep[6], daysOfSleep[7]);
                
            }
            sr.Close();
        }
        else
        {
            Console.WriteLine("File does not exist");
        }

}

