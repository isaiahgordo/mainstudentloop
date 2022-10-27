namespace mainstudentloop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string gmailhelp= "@govtdsb.ca", conread, soleline="", detailhelp="";
            int i, otherstnums, wherecomma = 0,whereperiod, on = 0, sOSN,off=1,whati=0;
            Random r = new Random();
            bool hier;
            otherstnums = r.Next(0, 10);
            otherstnums = otherstnums * 10 + r.Next(0, 10);
            otherstnums = otherstnums * 10 + r.Next(0, 10);
            sOSN = otherstnums;
            otherstnums = r.Next(0, 10);
            otherstnums = otherstnums * 10 + r.Next(0, 10);
            otherstnums = otherstnums * 10 + r.Next(0, 10);
            sOSN=sOSN*1000+otherstnums;
            List<string> student = new List<string>(), stmail = new List<string>(), helper=new List<string>();
            List<int>stunum = new List<int>();
            student.Add("Tuscan,Baillairge");
            stunum.Add(626);
            student.Add("Liam,Bale");
            stunum.Add(321);
            student.Add("Jacob,Battaglia");
            stunum.Add(773);
            student.Add("Jack,Beirnes-Daniel");
            stunum.Add(949);
            student.Add("Willow,Booker");
            stunum.Add(403);
            student.Add("Josiah,Brownlee");
            stunum.Add(533);
            student.Add("Jacob,Byers");
            stunum.Add(061);
            student.Add("Kain,Dufraimont");
            stunum.Add(118);
            student.Add("Jack,Eitel");
            stunum.Add(210);
            student.Add("Rowan,Ellis");
            stunum.Add(286);
            student.Add("Brandon,Fraser");
            stunum.Add(034);
            student.Add("Isaiah,Gordon");
            stunum.Add(857);
            student.Add("Cole,Groves");
            stunum.Add(568);
            student.Add("John,Higgs");
            stunum.Add(217);
            student.Add("Coutney,Kares");
            stunum.Add(644);
            student.Add("Simone,Kubisiowska-Borek");
            stunum.Add(053);
            student.Add("Dylane,Late");
            stunum.Add(446);
            student.Add("Kayleigh,Mortimer");
            stunum.Add(334);
            student.Add("Isaac,Roher");
            stunum.Add(298);
            student.Add("Owen,Rycroft");
            stunum.Add(607);
            student.Add("Zachary,Tucker");
            stunum.Add(752);
            student.Add("Hunter,Wilson");
            stunum.Add(604);
            student.Add("Alexander,Yuriaan");
            stunum.Add(977);
            for (i = 0; i < student.Count; i++)
            {
                helper.Add("");
                soleline = student[i];
                wherecomma = soleline.IndexOf(",");
                stmail.Add(student[i].Substring(wherecomma + 1, 4));
                stmail[i]=stmail[i]+student[i].Substring(0, 4) + stunum[i]+gmailhelp;
                Console.WriteLine(student[i]);
                helper[i] = student[i].Substring(0, 1) +","+ student[i].Substring(wherecomma+1,1);
            }
            while (on == 0)
            {
                Console.WriteLine("Choose one detail, add, remove, quit");
                conread = Console.ReadLine().Trim().ToLower();
                if (conread.StartsWith("de"))
                {
                    Console.WriteLine("on witch student");
                    while (off == 1)
                    {
                        soleline = Console.ReadLine().Trim();
                        wherecomma = soleline.IndexOf(",");
                        if (student.Contains(soleline)|helper.Contains(soleline))
                        {
                            for (i = 0; i < student.Count; i++)
                            {
                                hier = helper[i]==soleline | helper[i].StartsWith(soleline.Substring(0, 1)) && helper[i].EndsWith(soleline.Substring(wherecomma+1,1));
                                if (hier==true)
                                {
                                    detailhelp = sOSN * 100 + stunum[i].ToString();
                                    whati = i;
                                }
                                else
                                    Console.WriteLine("not an option");
                            }
                            Console.WriteLine(stmail[whati]);
                            Console.WriteLine(detailhelp);
                            off = 0;
                        }
                        else if (helper.Count<i)
                            Console.WriteLine("not an option");
                    }
                }
                else if (conread.StartsWith("a"))
                {
                    off = 1;
                    while(off == 1)
                    { 
                        Console.WriteLine("what is there firstname,lastname.last3studentnumbers?");
                        soleline = Console.ReadLine().Trim();
                        soleline = soleline.Substring(0, 1).ToUpper() + soleline.Substring(1);
                        if (soleline.Contains(",") && soleline.Contains("."))
                        {
                            wherecomma = soleline.IndexOf(",");
                            whereperiod = soleline.IndexOf(".");
                            Int32.TryParse(soleline.Substring(whereperiod + 1), out otherstnums);
                            stunum.Add(otherstnums);
                            soleline = soleline.Replace(soleline.Substring(wherecomma + 1, 1), soleline.Substring(wherecomma + 1, 1).ToUpper());
                            student.Add(soleline);
                            Console.WriteLine("done");
                        }
                        else
                            Console.WriteLine("you need a , and a .");
                        off = 0;
                    }
                }
                else if (conread.StartsWith("r"))
                {
                    Console.WriteLine("Enter the students name");
                    off = 1;
                    while (off == 1)
                    {
                        soleline = Console.ReadLine().Trim();
                        if (soleline.Contains(","))
                        {
                            soleline = soleline.Replace(soleline.Substring(0, 1), soleline.Substring(0, 1).ToUpper()) + soleline.Substring(1);
                            wherecomma = soleline.IndexOf(",");
                            soleline=soleline.Replace(soleline.Substring(wherecomma+1,1),soleline.Substring(wherecomma+1,1).ToUpper())+soleline.Substring(wherecomma+2);
                            for (i = 0; i < student.Count; i++)
                                if (soleline.Substring(0, 1).StartsWith(student[i].Substring(0, 1)) && soleline.Substring(wherecomma + 1, 1).StartsWith(student[i].Substring(wherecomma + 1, 1)) | student[i].Contains(soleline.Substring(0, 1)) && student[i].Contains(soleline.Substring(wherecomma + 1, 1)))
                                {
                                    student[i].Remove(i);
                                }
                                else
                                    Console.WriteLine(student[i]);
                        }
                        else
                            Console.WriteLine("you nee a ,");
                    }
                }
                else if (conread.StartsWith("q"))
                {
                    Console.WriteLine("Good bye");
                    on = 1;
                }
                else
                    Console.WriteLine("not an option");
            }
        }
    }
}