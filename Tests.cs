namespace xUnitTest
{
    public class JobTest
    {
        [Fact]
        public void CreateJob_WithBoundaryAttributes1_AllAttributesAdded()
        {
            //Assign
            Job job = new Job(999, 1, 1, 9);

            //Assert
            Assert.NotNull(job);
            Assert.IsType<Job>(job);
            Assert.True(999 == job.Id && 1 == job.TimeReceived &&
                        1 == job.ExecutionTime && 9 == job.Priority);
        }

        [Fact]
        public void CreateJob_WithBoundaryAttributes2_AllAttributesAdded()
        {
            //Assign
            Job job = new Job(1, 1, 1, 1);

            //Assert
            Assert.NotNull(job);
            Assert.IsType<Job>(job);
            Assert.True(1 == job.Id && 1 == job.TimeReceived &&
                        1 == job.ExecutionTime && 1 == job.Priority);
        }

        [Fact]
        public void CreateJob_WithIdEquals1000_ThrowArgumentOutOfRangeException()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Job(1000, 90, 23, 8));
        }

        [Fact]
        public void CreateJob_WithIdEquals0_ThrowArgumentOutOfRangeException()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Job(0, 90, 23, 8));
        }

        [Fact]
        public void CreateJob_WithTimeReceivedEquals0_ThrowArgumentOutOfRangeException()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Job(567, 0, 23, 8));
        }

        [Fact]
        public void CreateJob_WithExecutionTimeEquals0_ThrowArgumentOutOfRangeException()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Job(567, 90, 0, 8));
        }

        [Fact]
        public void CreateJob_WithPriorityEquals0_ThrowArgumentException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Job(567, 90, 23, 0));
        }

        [Fact]
        public void CreateJob_WithPriorityEquals10_ThrowArgumentException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new Job(567, 90, 23, 10));
        }

    }

    public class JobCollectionTest
    {
        [Fact]
        public void AddJobs_WithinCapacity_ReturnTrue()
        {
            //Assign
            uint capacity = 2;
            Job job1 = new Job(523, 90, 23, 8);
            JobCollection jobs = new JobCollection(capacity);

            //Assert
            Assert.True(jobs.Add(job1));
        }

        [Fact]
        public void AddJobs_WithinCapacity_ContainsAllJobs()
        {
            //Assign
            uint capacity = 2;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            JobCollection jobs = new JobCollection(capacity);
            //Act
            jobs.Add(job1);
            jobs.Add(job2);
            //Assert
            Assert.Contains(job1, jobs.ToArray());
            Assert.Contains(job2, jobs.ToArray());
        }

        [Fact]
        public void AddJobs_OverCapacity_OverCapacityOnesShouldReturnFalse()
        {
            //Assign
            uint capacity = 2;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            JobCollection jobs = new JobCollection(capacity);

            //Assert
            Assert.True(jobs.Add(job1));
            Assert.True(jobs.Add(job2));
            Assert.False(jobs.Add(job3));
        }

        [Fact]
        public void AddJobs_WithQuantityMoreThanCapacity_OverCapacityOnesShouldNotBeAdded()
        {
            //Assign
            uint capacity = 2;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            JobCollection jobs = new JobCollection(capacity);

            //Act
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            //Assert
            Assert.DoesNotContain(job3, jobs.ToArray());
        }

        [Fact]
        public void AddJobs_WithSameJobIdAdded_ReturnFlase()
        {
            //Assign
            uint capacity = 2;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(523, 11, 11, 6);
            JobCollection jobs = new JobCollection(capacity);

            //Assert
            Assert.True(jobs.Add(job1));
            Assert.False(jobs.Add(job2));
        }

        [Fact]
        public void AddJobs_WithNull_ReturnFlase()
        {
            //Assign
            uint capacity = 2;
            Job job1 = null;
            JobCollection jobs = new JobCollection(capacity);

            //Assert
            Assert.False(jobs.Add(job1));
        }

        [Fact]
        public void Contains_WithEmptyArray_ReturnFalse()
        {
            //Assign
            uint capacity = 2;
            JobCollection jobs = new JobCollection(capacity);
            uint searchId = 523;
            //Assert
            Assert.False(jobs.Contains(searchId));
        }

        [Fact]
        public void Contains_WithExistId_ReturnTrue()
        {
            //Assign
            uint capacity = 2;
            JobCollection jobs = new JobCollection(capacity);
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            uint searchId = 523;

            //Act
            jobs.Add(job1);
            jobs.Add(job2);

            //Assert
            Assert.True(jobs.Contains(searchId));
        }

        [Fact]
        public void Contains_WithNonExistId_ReturnFalse()
        {
            //Assign
            uint capacity = 2;
            JobCollection jobs = new JobCollection(capacity);
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            uint searchId = 111;

            //Act
            jobs.Add(job1);
            jobs.Add(job2);

            //Assert
            Assert.False(jobs.Contains(searchId));
        }

        [Fact]
        public void FindJob_WithExistId_ShouldEqualToTheJob()
        {
            //Assign
            uint capacity = 2;
            uint findJobId = 523;
            Job job1 = new Job(523, 90, 23, 8);
            JobCollection jobs = new JobCollection(capacity);
            //Act
            jobs.Add(job1);
            // Assert
            Assert.Equal(job1, jobs.Find(findJobId));
        }

        [Fact]
        public void FindJob_WithNonExistId_ReturnNull()
        {
            //Assign
            uint capacity = 2;
            uint findJobId = 111;
            Job job1 = new Job(523, 90, 23, 8);
            JobCollection jobs = new JobCollection(capacity);
            //Act
            jobs.Add(job1);
            // Assert
            Assert.Null(jobs.Find(findJobId));
        }


        [Fact]
        public void RemoveJobs_WithExistJobId_ReturnTrue()
        {
            //Assign
            uint capacity = 2;
            uint removedJobId = 523;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            JobCollection jobs = new JobCollection(capacity);
            //Act
            jobs.Add(job1);
            jobs.Add(job2);

            //Assert
            Assert.True(jobs.Remove(removedJobId));
        }

        [Fact]
        public void RemoveJobs_RemoveOneJob_DoesNotContainRemovedJob()
        {
            //Assign
            uint capacity = 2;
            uint removedJobId = 523;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            JobCollection jobs = new JobCollection(capacity);
            //Act
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Remove(removedJobId);
            //Assert
            Assert.DoesNotContain(job1, jobs.ToArray());
        }

        [Fact]
        public void RemoveJobs_WithNonExistJobId_ReturnFalse()
        {
            //Assign
            uint capacity = 2;
            uint removedJobId = 111;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            JobCollection jobs = new JobCollection(capacity);
            //Act
            jobs.Add(job1);
            jobs.Add(job2);

            //Assert
            Assert.False(jobs.Remove(removedJobId));
        }

        [Fact]
        public void ToArray_WithAnArray_ReturnNewArrayWithSameElements()
        {
            //Assign
            uint capacity = 2;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            JobCollection jobs = new JobCollection(capacity);

            //Act
            jobs.Add(job1);
            jobs.Add(job2);
            IJob[] answer = { job1, job2 };

            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.Equal<IJob>(answer[i], jobs.ToArray()[i]);
            }
        }
        [Fact]
        public void ToArray_WithAnArrayOfNoElements_ReturnEmptyArray()
        {
            //Assign
            uint capacity = 2;
            JobCollection jobs = new JobCollection(capacity);

            //Assert
            Assert.Empty(jobs.ToArray());
        }
    }

    public class SchedulerTest
    {
        [Fact]
        public void FCFS_WithEmptyScheduler_ReturnEmptyArray()
        {
            //Assign
            uint capacity = 5;
            JobCollection jobs = new JobCollection(capacity);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.FirstComeFirstServed();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void FCFS_WithNormalScheduler_ReturnArrayFollowingFCFSRule()
        {
            //Assign
            uint capacity = 5;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            Job job4 = new Job(553, 35, 12, 1);
            Job job5 = new Job(346, 79, 6, 5);
            JobCollection jobs = new JobCollection(capacity);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            jobs.Add(job4);
            jobs.Add(job5);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.FirstComeFirstServed();
            IJob[] answer = { job3, job4, job2, job5, job1 };
            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.Equal<IJob>(answer[i], result[i]);
            }
        }

        [Fact]
        public void FCFS_WithSameTimeReceived_ReturnArrayWithRandomOrderForSameTimeReceivedJobsFollowingFCFSRule()
        {
            //Assign
            uint capacity = 5;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 90, 50, 5);
            Job job4 = new Job(553, 35, 12, 1);
            Job job5 = new Job(346, 79, 6, 5);
            JobCollection jobs = new JobCollection(capacity);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            jobs.Add(job4);
            jobs.Add(job5);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.FirstComeFirstServed();
            IJob[] answer1 = { job4, job2, job5, job1, job3 };
            IJob[] answer2 = { job4, job2, job5, job3, job1 };
            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.True((answer1[i] == result[i]) || (answer2[i] == result[i]));
            }
        }

        [Fact]
        public void Priority_WithEmptyScheduler_ReturnEmptyArra()
        {
            //Assign
            uint capacity = 5;
            JobCollection jobs = new JobCollection(capacity);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.Priority();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Priority_WithNormalScheduler_ReturnArrayFollowingPriorityRule()
        {
            //Assign
            uint capacity = 5;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            Job job4 = new Job(553, 35, 12, 1);
            Job job5 = new Job(346, 79, 6, 6);
            JobCollection jobs = new JobCollection(capacity);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            jobs.Add(job4);
            jobs.Add(job5);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.Priority();
            IJob[] answer = { job1, job5, job3, job2, job4 };
            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.Equal<IJob>(answer[i], result[i]);
            }
        }

        [Fact]
        public void Priority_WithSamePriority_ReturnArrayWithRandomOrderForSamePriorityJobsFollowingPriorityRule()
        {
            //Assign
            uint capacity = 5;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            Job job4 = new Job(553, 35, 12, 1);
            Job job5 = new Job(346, 79, 6, 5);
            JobCollection jobs = new JobCollection(capacity);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            jobs.Add(job4);
            jobs.Add(job5);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.Priority();
            IJob[] answer1 = { job1, job5, job3, job2, job4 };
            IJob[] answer2 = { job1, job3, job5, job2, job4 };
            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.True((answer1[i] == result[i]) || (answer2[i] == result[i]));
            }
        }

        [Fact]
        public void SJF_WithEmptyScheduler_ReturnEmptyArra()
        {
            //Assign
            uint capacity = 5;
            JobCollection jobs = new JobCollection(capacity);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.ShortestJobFirst();

            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SJF_WithNormalScheduler_ReturnArrayFollowingSJFRule()
        {
            //Assign
            uint capacity = 5;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            Job job4 = new Job(553, 35, 12, 1);
            Job job5 = new Job(346, 79, 6, 6);
            JobCollection jobs = new JobCollection(capacity);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            jobs.Add(job4);
            jobs.Add(job5);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.ShortestJobFirst();
            IJob[] answer = { job5, job4, job2, job1, job3 };
            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.Equal<IJob>(answer[i], result[i]);
            }
        }

        [Fact]
        public void SJF_WithSameSJF_ReturnArrayWithRandomOrderForSameExecutionTimeJobsFollowingSJFRule()
        {
            //Assign
            uint capacity = 5;
            Job job1 = new Job(523, 90, 23, 8);
            Job job2 = new Job(966, 46, 15, 2);
            Job job3 = new Job(26, 11, 50, 5);
            Job job4 = new Job(553, 35, 23, 1);
            Job job5 = new Job(346, 79, 6, 5);
            JobCollection jobs = new JobCollection(capacity);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);
            jobs.Add(job4);
            jobs.Add(job5);
            Scheduler sch = new Scheduler(jobs);
            IJob[] result = sch.ShortestJobFirst();
            IJob[] answer1 = { job5, job2, job1, job4, job3 };
            IJob[] answer2 = { job5, job2, job4, job1, job3 };
            //Assert
            for (int i = 0; i < jobs.Count; i++)
            {
                Assert.True((answer1[i] == result[i]) || (answer2[i] == result[i]));
            }
        }
    }
}