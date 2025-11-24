public interface ILead
{
   void AssignTasks();
   void WorkOnTask();
   void CreateSubTasks();
}

public class TeamLead : ILead
{
   public void AssignTask()
   {
      //Code to assign a task.
   }
   public void CreateSubTask()
   {
      //Code to create a sub task
   }
   public void WorkOnTask()
   {
      //Code to implement perform assigned task.
   }
}

// OK. The design looks fine for now. However, later another role, like Manager, who assigns tasks to TeamLead and will not work on the tasks, is introduced into the system. Can we directly implement an ILead interface in the Manager class, like the following?

public class Manager: ILead
{
   public void AssignTask()
   {
      //Code to assign a task.
   }
   public void CreateSubTask()
   {
      //Code to create a sub task.
   }
   public void WorkOnTask()
   {
      throw new Exception("Manager can't work on Task");
   }
}



public class Manager: ILead
{
   public void AssignTask()
   {
      //Code to assign a task.
   }
   public void CreateSubTask()
   {
      //Code to create a sub task.
   }
   public void WorkOnTask()
   {
      throw new Exception("Manager can't work on Task");
   }
}

// Since the Manager can't work on a task and, at the same time, no one can assign tasks to the Manager, this WorkOnTask() should not be in the Manager class. But we are implementing this class from the ILead interface; we must provide a concrete Method. Here we are forcing the Manager class to implement a WorkOnTask() method without a purpose. This is wrong. The design violates ISP. Let's correct the design.

// Since we have three roles, 
// 1, managers can only divide and assign tasks, 
// 2. TeamLead can divide and assign the jobs and work on them, 
// 3. We need to divide the responsibilities by segregating the ILead interface for the programmer that can only work on tasks, an interface that provides a contract for WorkOnTask().

public interface IProgrammer
{
   void WorkOnTask();
}
// An interface that provides contracts to manage the tasks:

public interface ILead
{
   void AssignTask();
   void CreateSubTask();
}
// Then the implementation becomes.

public class Programmer: IProgrammer
{
   public void WorkOnTask()
   {
      //code to implement to work on the Task.
   }
}
public class Manager: ILead
{
   public void AssignTask()
   {
      //Code to assign a Task
   }
   public void CreateSubTask()
   {
   //Code to create a sub taks from a task.
   }
}

// TeamLead can manage tasks and can work on them if needed. Then the TeamLead class should implement both the IProgrammer and ILead interfaces.

public class TeamLead: IProgrammer, ILead
{
   public void AssignTask()
   {
      //Code to assign a Task
   }
   public void CreateSubTask()
   {
      //Code to create a sub task from a task.
   }
   public void WorkOnTask()
   {
      //code to implement to work on the Task.
   }
}
// Wow. Here we separated responsibilities/purposes, distributed them on multiple interfaces, and provided good abstraction.