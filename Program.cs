// Suppose we have a Rectangle class with the properties Height and Width.


public class Rectangle{
   public double Height {get;set;}
   public double Wight {get;set; }
}

// Our app needs to calculate the total area of a collection of Rectangles. Since we already learned the Single Responsibility Principle (SRP), we don't need to put the total area calculation code inside the rectangle. 
// So here, I created another class for area calculation.

public class AreaCalculator {
   public double TotalArea(Rectangle[] arrRectangles)
   {
      double area;
      foreach(var objRectangle in arrRectangles)
      {
         area += objRectangle.Height * objRectangle.Width;
      }
      return area;
   }
}

// Hey, we did it. We made our app without violating SRP. No issues for now. But can we extend our app so that it can calculate the area of not only Rectangles but also the area of Circles? 
// Now we have an issue with the area calculation issue because the way to calculate the circle area is different. Hmm. Not a big deal. We can change the TotalArea method to accept an array of objects as an argument.
// We check the object type in the loop and do area calculations based on the object type.  

public class Rectangle{
   public double Height {get;set;}
   public double Wight {get;set; }
}
public class Circle{
   public double Radius {get;set;}
}
public class AreaCalculator
{
   public double TotalArea(object[] arrObjects)
   {
      double area = 0;
      Rectangle objRectangle;
      Circle objCircle;
      foreach(var obj in arrObjects)
      {
         if(obj is Rectangle)
         {
            area += obj.Height * obj.Width;
         }
         else
         {
            objCircle = (Circle)obj; // forcefully casting the object to a circle such that the only field it has is Radius.
            area += objCircle.Radius * objCircle.Radius * Math.PI;
         }
      }
      return area;
   }
}

// Wow. We are done with the change. Here we successfully introduced Circle into our app. We can add a Triangle and calculate its area by adding one more "if" block in the TotalArea method of AreaCalculator. 
// But every time we introduce a new shape, we must alter the TotalArea method. So the AreaCalculator class is not closed for modification. 
// How can we make our design to avoid this situation? Generally, we can do this by referring to abstractions for dependencies, such as interfaces or abstract classes, rather than using concrete classes. 
// Such interfaces can be fixed once developed so the classes that depend upon them can rely upon unchanging abstractions. Functionality can be added by creating new classes that implement the interfaces. So let's refract our code using an interface.

public abstract class Shape
{
   public abstract double Area();
}

// Inheriting from Shape, the Rectangle and Circle classes now look like this:  

public class Rectangle: Shape
{
   public double Height {get;set;}
   public double Width {get;set;}
   public override double Area()
   {
      return Height * Width;
   }
}
public class Circle: Shape
{
   public double Radius {get;set;}
   public override double Area()
   {
      return Radius * Radius * Math.PI;
   }
}
// C#
// Every shape contains its area with its way of calculation functionality, and our AreaCalculator class will become simpler than before.

public class AreaCalculator
{
   public double TotalArea(Shape[] arrShapes)
   {
      double area=0;
      foreach(var objShape in arrShapes)
      {
         area += objShape.Area();
      }
      return area;
   }
}

// Now our code is following SRP and OCP both. Whenever you introduce a new shape by deriving from the "Shape" abstract class, you need not change the "AreaCalculator" class. Awesome. Isn't it?
