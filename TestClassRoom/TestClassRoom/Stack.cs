

namespace TestProject
{
    public class MyStack<T>
    {
        int capacity;
        T[] stack;
        int top;
        public MyStack(int MaxElements)
        {
            capacity = MaxElements;
            stack = new T[capacity];
        }
        public void Push(T Element)
        {
            if (top == capacity)
                Console.WriteLine("Stack Overflow !");
            else
            {    
                stack[top] = Element;
                top = top + 1;
                Console.WriteLine($"Element '{Element}' pushed into Stack !");
            }
        }
        public T Pop()
        {
            T RemovedElement;
            if (!(top <= 0))
            {
                top = top - 1;
                RemovedElement = stack[top];
                stack[top] = default(T);     
                return RemovedElement;
            }
            else
                return default(T);
        }

        public void ClearStack()
        {
            Array.Clear(stack);
            Console.WriteLine("Stack has been cleaned");
        }

        public int CountStack()
        {
            return stack.Count();
        }
        public T Peek()
        {
            if (!(top <= 0))
                return stack[top-1];
            else
                return default(T);
        }
        public void CopyStackToArray(Array newArray) 
        {
            stack.CopyTo(newArray, 0);    
        }
    }
}
