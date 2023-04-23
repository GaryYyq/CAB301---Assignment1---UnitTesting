

    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                Job job1 = new Job(523, 90, 23, 8);
                Job job2 = new Job(966, 46, 15, 2);
                Job job3 = new Job(26, 11, 50, 5);
                Job job4 = new Job(553, 35, 12, 1);
                Job job5 = new Job(346, 79, 6, 5);
                Job job6 = new Job(560, 95, 47, 2);
                Job job7 = new Job(132, 13, 18, 8);
                Job job8 = new Job(741, 92, 37, 9);
                Job job9 = new Job(267, 11, 50, 5);
                Job job10 = new Job(583, 97, 22, 2);
                //Job job11 = new Job(522, 97, 22, 2);
            //Job job5 = new Job(123, 20, 16, 5); //same id with job 4

            JobCollection jobs = new JobCollection(10);
            
                jobs.ToArray();
                jobs.Add(job1);
                jobs.Add(job2);
                jobs.Add(job3);
                jobs.Add(job4);
                jobs.Add(job5);
                jobs.Add(job6);
                jobs.Add(job7);
                jobs.Add(job8);
                jobs.Add(job9);
                jobs.Add(job10);
                //jobs.Add(job11);
                //Test remove method
                //Console.WriteLine("Test remove method");
                //Console.WriteLine("Before remove method");
                //for (int i = 0; i < jobs.Count; i++)
                //{
                //    Console.WriteLine(jobs.ToArray()[i]);
                //}
                //jobs.Remove(523);
                //Console.WriteLine("After remove method - remove job id is 523");
                //for (int i = 0; i < jobs.Count; i++)
                //{
                //    Console.WriteLine(jobs.ToArray()[i]);
                //}

                IJob[] jobsArr = jobs.ToArray();
                //Console.WriteLine(jobsArr.Length);
                //Console.WriteLine(jobsArr);

                //for (uint i = 0; i < jobsArr.Length; i++)
                //{
                //    Console.WriteLine(jobsArr[i]);
                //}
                //foreach(IJob job in jobs.ToArray())
                //{
                //    Console.WriteLine(job.Id);
                //}
                Scheduler sch = new Scheduler(jobs);
                Console.WriteLine("First Come First Served");
                
                IJob[] fcfsArr = sch.FirstComeFirstServed();
                //Console.WriteLine(fcfsArr.Length);
                for (uint i = 0; i < fcfsArr.Length; i++)
                {
                    Console.WriteLine(fcfsArr[i]);
                }
                Console.WriteLine("Shortest Job First");
                IJob[] sjfArr = sch.ShortestJobFirst();
                for (uint i = 0; i < sjfArr.Length; i++)
                {
                    Console.WriteLine(sjfArr[i]);
                }
                Console.WriteLine("Priority");
                IJob[] pArr = sch.Priority();
                for (uint i = 0; i < pArr.Length; i++)
                {
                    Console.WriteLine(pArr[i]);
                }
                //Console.WriteLine(sch.Jobs.ToArray()[0]);
            }
            catch (ArgumentOutOfRangeException ex)
            {
            //    //Console.WriteLine($"the ID is: {ex.ParamName} here");
            //    //if (ex.ParamName == "Id")
            //    //{
            //    //    Console.WriteLine($"line : {ex.ParamName} here");
            //    //}
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException)
            {
                //Console.WriteLine($"the Priority is: {ex.Message} here");
            }
        



        }
    }


