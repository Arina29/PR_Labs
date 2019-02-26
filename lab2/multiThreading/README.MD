# Laboratory Work nr.2
## Multithreading programming
![alt text](https://github.com/Arina29/PR_Labs/blob/master/lab2Varianta.png "Logo Title Text 1")
 In order to accomplish this task, I used the TPL, I prefer Task Parallel Library over explicit thread handling, as it is more optimized.
 1. As we can see in the exercise, the tasks:5 and 6 should be executed in parallel, so here I used _Parallel.Invoke(action1,action2)_ method that executes the task in parallel on different threads and waits until the tasks are finished, then it proceed to task 2.
2. For the second task I created a new thread using  _Task.Factory.StartNew(() => writeNode(1));_ which creates a new thread if necessary and execute the corresponding function.
3. After this step we can notice that Task3 should wait for Task 2 to acomplish and Task 1 should wait for Task 2 and Task 3, so I used: _Task.WaitAll(task2);_ and _Task.WaitAll(task2, task3);_, that waits for all of the provided Task objects to complete execution.
SO, first of all tasks __5__ and __6__ will be executed than __2__, after this __task3__ and finally __task1__

